using Lib_D2Data.Dictionaries;
using Lib_D2Data.Equipment;
using Lib_D2Data.Exceptions;
using Lib_D2Data.Items;
using Lib_D2Data.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lib_D2Data
{
    public static class D2Data
    {
        public static readonly D2DataSetup setup = new D2DataSetup();
        private static bool isDataLoaded = LoadIfNotLoaded();
        public static List<Unique> Uniques { get; set; }
        public static List<Runeword> Runewords { get; set; }
        public static List<CubeRecipe> CubeRecipes { get; set; }
        public static List<Set> Sets { get; set; }

        public static bool libraryReady = false;

        public static bool IsDataLoaded { get {  return isDataLoaded; } }

        public static bool LoadIfNotLoaded()
        {
            if (!IsDataLoaded) LoadData();

            return IsDataLoaded;
        }

        public static bool IsLibraryRead()
        {
            return libraryReady;
        }

        public static void SetLibraryReady(bool val)
        {
            libraryReady = val;
        }

        public static void LoadData()
        {
            Console.WriteLine("Calling LoadData");
            try
            {
                Table.ImportFromTbl(setup.tableDirectory);
                MagicPrefix.Import(setup.excelDirectory);
                MagicSuffix.Import(setup.excelDirectory);
                ItemStatCost.Import(setup.excelDirectory);
                EffectProperty.Import(setup.excelDirectory);
                ItemType.Import(setup.excelDirectory);
                Armor.Import(setup.excelDirectory);
                Weapon.Import(setup.excelDirectory);
                Skill.Import(setup.excelDirectory);
                CharStat.Import(setup.excelDirectory);
                MonStat.Import(setup.excelDirectory);
                Misc.Import(setup.excelDirectory);
                Gem.Import(setup.excelDirectory);
                SetItem.Import(setup.excelDirectory);
                ImportModel();
                isDataLoaded = true;
                SetLibraryReady(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ExceptionHandler.WriteException(e);
            }
        }

        public static void ImportModel()
        {
            try
            {
                Uniques = Unique.Import(setup.excelDirectory);
                Runewords = Runeword.Import(setup.excelDirectory);
                CubeRecipes = CubeRecipe.Import(setup.excelDirectory);
                Sets = Set.Import(setup.excelDirectory);
            }
            catch (Exception e)
            {
                ExceptionHandler.WriteException(e);
            }
        }

        public static List<string> ReadTxtFileToList(string path)
        {
            return File.ReadAllLines(path).ToList();
        }

        public static List<Dictionary<string, string>> ReadTxtFileToDictionaryList(string path)
        {
            var table = new List<Dictionary<string, string>>();

            var fileArray = File.ReadAllLines(path);
            var headerArray = fileArray.Take(1).First().Split('\t');

            var header = new List<string>();

            foreach (var column in headerArray)
            {
                header.Add(column);
            }

            var dataArray = fileArray.Skip(1);
            foreach (var valueLine in dataArray)
            {
                var values = valueLine.Split('\t');
                if (string.IsNullOrEmpty(values[1]))
                {
                    continue;
                }

                var row = new Dictionary<string, string>();

                for (var i = 0; i < values.Length; i++)
                {
                    row[headerArray[i]] = values[i];
                }

                table.Add(row);
            }

            return table;
        }

    }
}
