using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lib_D2Data.Dictionaries
{
    public class MagicPrefix
    {
        public string Name { get; set; }

        [JsonIgnore]
        public int Index { get; set; }

        [JsonIgnore]
        public static Dictionary<int, MagicPrefix> MagicPrefixes;

        public static void Import(string excelFolder)
        {
            MagicPrefixes = new Dictionary<int, MagicPrefix>();

            var table = D2Data.ReadTxtFileToDictionaryList(excelFolder + "/MagicPrefix.txt");
            var index = 0;

            foreach (var row in table)
            {
                var magicPrefix = new MagicPrefix
                {
                    Name = row["Name"],
                    Index = index
                };

                MagicPrefixes[index] = magicPrefix;

                index++;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}