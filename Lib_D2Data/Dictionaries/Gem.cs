﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Lib_D2Data.Items;
using Lib_D2Data.Types;
using Lib_D2Data.Exceptions;

namespace Lib_D2Data.Dictionaries
{
    public class Gem : Item
    {
        public new string Name { get { return Index; } }
        [JsonIgnore]
        public string Letter { get; set; }
        [JsonIgnore]
        public int NumMods { get; set; }
        [JsonIgnore]
        public List<ItemProperty> WeaponProperties { get; set; }
        [JsonIgnore]
        public List<ItemProperty> HelmProperties { get; set; }
        [JsonIgnore]
        public List<ItemProperty> ShieldProperties { get; set; }

        [JsonIgnore]
        public static Dictionary<string, Gem> Gems;

        public static void Import(string excelFolder)
        {
            Gems = new Dictionary<string, Gem>();

            var table = D2Data.ReadTxtFileToDictionaryList(excelFolder + "/Gems.txt");

            foreach (var row in table)
            {
                var numMods = Utility.ToNullableInt(row["nummods"]);
                if (!numMods.HasValue)
                {
                    ExceptionHandler.LogException(new Exception($"Invalid nummods for '{row["name"]}' in Gems.txt"));
                }

                var gem = new Gem
                {
                    Index = row["name"],
                    Letter = row["letter"],
                    Code = row["code"],
                    NumMods = numMods.Value,
                };

                // Add the properties
                var propList = new List<Types.PropertyInfo>();
                for (int i = 1; i <= 3; i++)
                {
                    propList.Add(new Types.PropertyInfo(row[$"weaponMod{i}Code"], row[$"weaponMod{i}Param"], row[$"weaponMod{i}Min"], row[$"weaponMod{i}Max"]));
                }

                try
                {
                    var properties = ItemProperty.GetProperties(propList).OrderByDescending(x => x.ItemStatCost == null ? 0 : x.ItemStatCost.DescriptionPriority).ToList();
                    gem.WeaponProperties = properties;
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get weapon properties for gem '{gem.Index}' in Gems.txt", e));
                }

                // Add the properties
                propList = new List<Types.PropertyInfo>();
                for (int i = 1; i <= 3; i++)
                {
                    propList.Add(new Types.PropertyInfo(row[$"helmMod{i}Code"], row[$"helmMod{i}Param"], row[$"helmMod{i}Min"], row[$"helmMod{i}Max"]));
                }

                try
                {
                    var properties = ItemProperty.GetProperties(propList).OrderByDescending(x => x.ItemStatCost == null ? 0 : x.ItemStatCost.DescriptionPriority).ToList();
                    gem.HelmProperties = properties;
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get helm properties for gem '{gem.Index}' in Gems.txt", e));
                }


                // Add the properties
                propList = new List<Types.PropertyInfo>();
                for (int i = 1; i <= 3; i++)
                {
                    propList.Add(new Types.PropertyInfo(row[$"shieldMod{i}Code"], row[$"shieldMod{i}Param"], row[$"shieldMod{i}Min"], row[$"shieldMod{i}Max"]));
                }

                try
                {
                    var properties = ItemProperty.GetProperties(propList).OrderByDescending(x => x.ItemStatCost == null ? 0 : x.ItemStatCost.DescriptionPriority).ToList();
                    gem.ShieldProperties = properties;
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(new Exception($"Could not get shield properties for gem '{gem.Index}' in Gems.txt", e));
                }

                Gems[gem.Index] = gem;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}