﻿using System.Collections.Generic;
using System.IO;
using Lib_D2Data.Exceptions;
using Newtonsoft.Json;

namespace Lib_D2Data.Dictionaries
{
    public class Table
    {
        [JsonIgnore]
        public static Dictionary<string, string> Tables;

        public static void ImportFromTxt(string tableFolder)
        {
            Tables = new Dictionary<string, string>();

            var files = Directory.GetFiles(tableFolder, "*.txt");
            foreach (var file in files)
            {
                var lines = D2Data.ReadTxtFileToList(file);

                foreach (var line in lines)
                {
                    var values = line.Split('\t');

                    var key = values[0].Trim('"');
                    var value = values[1].Trim('"');

                    if (string.IsNullOrEmpty(key))
                    {
                        continue;
                    }

                    Tables[key] = value;
                }
            }
        }

        public static void ImportFromTbl(string tableFolder)
        {
            Tables = new Dictionary<string, string>();

            var files = Directory.GetFiles(tableFolder, "*.tbl");

            if (files.Length == 0)
            {
                ExceptionHandler.LogException(new System.Exception($"Could not find any .tbl files in '{tableFolder}'"));
            }

            foreach (var file in files)
            {
                var hashTable = TableProcessor.ReadTablesFile(file);

                foreach (var tableEntry in hashTable)
                {
                    Tables[tableEntry.Key] = tableEntry.Value;
                }
            }

            FixBrokenValues();
        }

        public static string GetValue(string key)
        {
            var value = string.Empty;

            if (key == "tpfs") key = "opl";
            if (key == "tpcs") key = "cps";
            if (key == "tpls") key = "lps";
            if (key == "tpgs") key = "gpl";
            if (key == "tpfm") key = "opm";
            if (key == "tpcm") key = "cpm";
            if (key == "tplm") key = "lpm";
            if (key == "tpgm") key = "gpm";
            if (key == "tpfl") key = "ops";
            if (key == "tpcl") key = "cpl";
            if (key == "tpll") key = "lpl";
            if (key == "tpgl") key = "gps";



            if (Tables.ContainsKey(key))
            {
                value = Tables[key];

                // Fix class skills
                if (key == "ModStr3a")
                {
                    value = value.Replace("Amazon", "%d");
                }

                return value;
            }

            if (!string.IsNullOrEmpty(key))
            {
                // System.Console.WriteLine("Adding [" + key + "] to the couldn't find list.");
                ExceptionHandler.LogException(new System.Exception($"Could not find key '{key}' in any .tbl file"));
            }

            return key;
        }

        private static void FixBrokenValues()
        {
            var skillDictionary = new Dictionary<string, string>
               {
                   {"StrSklTabItem1", "+%d to Javelin and Spear Skills"},
                    {"StrSklTabItem2", "+%d to Passive and Magic Skills"},
                    {"StrSklTabItem3", "+%d to Bow and Crossbow Skills"},
                    {"StrSklTabItem4", "+%d to Defensive Auras"},
                    {"StrSklTabItem5", "+%d to Offensive Auras"},
                    {"StrSklTabItem6", "+%d to Combat Skills"},
                    {"StrSklTabItem7", "+%d to Summoning Skills"},
                    {"StrSklTabItem8", "+%d to Poison and Bone Skills"},
                    {"StrSklTabItem9", "+%d to Curses"},
                    {"StrSklTabItem10", "+%d to Warcries"},
                    {"StrSklTabItem11", "+%d to Combat Skills"},
                    {"StrSklTabItem12", "+%d to Masteries"},
                    {"StrSklTabItem13", "+%d to Cold Skills"},
                    {"StrSklTabItem14", "+%d to Lightning Skills"},
                    {"StrSklTabItem15", "+%d to Fire Skills"},
                    {"StrSklTabItem16", "+%d to Summoning Skills"},
                    {"StrSklTabItem17", "+%d to Shape Shifting Skills"},
                    {"StrSklTabItem18", "+%d to Elemental Skills"},
                    {"StrSklTabItem19", "+%d to Traps"},
                    {"StrSklTabItem20", "+%d to Shadow Disciplines"},
                    {"StrSklTabItem21", "+%d to Martial Arts"}
               };

            foreach (var skill in skillDictionary)
            {
                Tables[skill.Key] = skill.Value;
            }
        }
    }
}
