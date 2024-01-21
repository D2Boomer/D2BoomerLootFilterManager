﻿using System;
using System.Collections.Generic;
using Lib_D2Data.Dictionaries;
using Lib_D2Data.Types;
using Newtonsoft.Json;

namespace Lib_D2Data.Items
{
    public class Item
    {
        [JsonIgnore]
        public static Item CurrentItem { get; set; }

        public string Name
        {
            get
            {
                if (!Table.Tables.ContainsKey(Index))
                {
                    throw new Exception($"Could not find translation for '{Index}' in any .tbl files");
                }

                return Table.Tables[Index];
            }
        }
        public string Index { get; set; }
        public bool Enabled { get; set; }
        public int ItemLevel { get; set; }
        public int RequiredLevel { get; set; }
        public string Code { get; set; }
        public List<ItemProperty> Properties { get; set; }
        public bool DamageArmorEnhanced { get; set; }
        public Equipment.Equipment Equipment { get; set; }

        public Item()
        {
            CurrentItem = this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
