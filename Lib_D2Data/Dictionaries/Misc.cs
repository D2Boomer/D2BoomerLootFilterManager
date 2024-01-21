using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lib_D2Data.Exceptions;
using Newtonsoft.Json;

namespace Lib_D2Data.Dictionaries
{
    public class Misc
    {
        public string Name { get; set; }
        public int ItemLevel { get; set; }
        public int RequiredLevel { get; set; }

        [JsonIgnore]
        public string Code { get; set; }

        public ItemType Type { get; set; }

        [JsonIgnore]
        public string Type2 { get; set; }

        [JsonIgnore]
        public static Dictionary<string, Misc> MiscItems;

        [JsonIgnore]
        public static Dictionary<string, Misc> MiscAccessories;

        [JsonIgnore]
        public static Dictionary<string, Misc> MiscCharms;

        [JsonIgnore]
        public static Dictionary<string, Misc> MiscJewels;

        public static void Import(string excelFolder)
        {
            MiscItems = new Dictionary<string, Misc>();
            MiscAccessories = new Dictionary<string, Misc>();
            MiscCharms = new Dictionary<string, Misc>();
            MiscJewels = new Dictionary<string, Misc>();

            var table = D2Data.ReadTxtFileToDictionaryList(excelFolder + "/Misc.txt");

            foreach (var row in table)
            {
                if (string.IsNullOrEmpty(row["code"]))
                {
                    continue;
                }

                var name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(row["name"].Replace(" Rune", ""));

                if (!ItemType.ItemTypes.ContainsKey(row["type"]))
                {
                    ExceptionHandler.LogException(new Exception($"Could not find code '{row["type"]}' in ItemTypes.txt for type field in Misc.txt item {name}"));
                }

                var itemLevel = Utility.ToNullableInt(row["level"]);
                if (!itemLevel.HasValue)
                {
                    ExceptionHandler.LogException(new Exception($"Could not find item level for '{name}' in Misc.txt"));
                }

                var requiredLevel = Utility.ToNullableInt(row["levelreq"]);
                if (!requiredLevel.HasValue)
                {
                    ExceptionHandler.LogException(new Exception($"Could not find required level for '{name}' in Misc.txt"));
                }

                var misc = new Misc
                {
                    Name = row["name"],
                    ItemLevel = itemLevel.Value,
                    RequiredLevel = requiredLevel.Value,
                    Code = row["code"],
                    Type = ItemType.ItemTypes[row["type"]],
                    Type2 = row["type2"]
                };

                MiscItems[misc.Code] = misc;

                if (!MiscAccessories.ContainsKey(misc.Code)) {
                    if (misc.Type.Name.ToLower().Contains("amulet")) MiscAccessories[misc.Code] = misc;
                    if (misc.Type.Name.ToLower().Contains("quiver")) MiscAccessories[misc.Code] = misc;
                    if (misc.Type.Name.ToLower().Contains("ring")) MiscAccessories[misc.Code] = misc;
                }

                if (!MiscCharms.ContainsKey(misc.Code))
                {
                    if (misc.Type.Name.ToLower().Contains("charm")) MiscCharms[misc.Code] = misc;
                }

                if (!MiscJewels.ContainsKey(misc.Code))
                {
                    if (misc.Type.Name.ToLower().Contains("jewel")) MiscJewels[misc.Code] = misc;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}