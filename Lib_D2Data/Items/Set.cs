using Lib_D2Data.Exceptions;
using Lib_D2Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib_D2Data.Items
{
    public class Set
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public List<SetItem> SetItems { get; set; }
        public List<ItemProperty> PartialProperties { get; set; }
        public List<ItemProperty> FullProperties { get; set; }
        public int Level { get; set; }

        public static List<Set> Import(string excelFolder)
        {
            var result = new List<Set>();

            var table = D2Data.ReadTxtFileToDictionaryList(excelFolder + "/Sets.txt");

            foreach (var row in table)
            {

                var set = new Set
                {
                    Index = row["index"],
                    Name = row["name"]
                };

                var level = Utility.ToNullableInt(row["level"]);
                if (!level.HasValue)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get level of set {set.Name} from Sets.txt"));
                }

                set.Level = level.Value;

                var propList = new List<Types.PropertyInfo>();
                // Add the properties
                for (int i = 2; i <= 5; i++)
                {
                    propList.Add(new Types.PropertyInfo(row[$"PCode{i}a"], row[$"PParam{i}a"], row[$"PMin{i}a"], row[$"PMax{i}a"]));
                    propList.Add(new Types.PropertyInfo(row[$"PCode{i}b"], row[$"PParam{i}b"], row[$"PMin{i}b"], row[$"PMax{i}b"]));
                }

                try
                {
                    var properties = ItemProperty.GetProperties(propList, set.Level).OrderByDescending(x => x.ItemStatCost == null ? 0 : x.ItemStatCost.DescriptionPriority).ToList();
                    set.PartialProperties = properties.OrderBy(x => x.Index).ToList();
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get properties for set '{set.Name}' in Sets.txt", e));
                }

                propList = new List<Types.PropertyInfo>();
                // Add the properties
                for (int i = 1; i <= 8; i++)
                {
                    propList.Add(new Types.PropertyInfo(row[$"FCode{i}"], row[$"FParam{i}"], row[$"FMin{i}"], row[$"FMax{i}"]));
                }

                try
                {
                    var propertiesFull = ItemProperty.GetProperties(propList, set.Level).OrderByDescending(x => x.ItemStatCost == null ? 0 : x.ItemStatCost.DescriptionPriority).ToList();
                    set.FullProperties = propertiesFull;
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get properties for set '{set.Name}' in Sets.txt", e));
                }

                set.SetItems = SetItem.SetItems.Where(x => x.Set == set.Index).ToList();

                result.Add(set);
            }

            return result.OrderBy(x => x.Level).ToList();
        }
    }
}