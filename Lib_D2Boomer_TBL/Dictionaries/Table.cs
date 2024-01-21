﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Boomer_TBL.Dictionaries
{
    public class Table
    {
        public static Dictionary<string, string> Tables;

        public static Dictionary<string, string> ImportFromTbl(string tableFolder)
        {
            Tables = new Dictionary<string, string>();

            var files = Directory.GetFiles(tableFolder, "*.tbl");

            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    var hashTable = TableProcessor.ReadTablesFile(file);

                    foreach (var tableEntry in hashTable)
                    {
                        Tables[tableEntry.Key] = tableEntry.Value;
                    }
                }
            }

            FixBrokenValues();

            return Tables;
        }

        public static string GetValue(string key)
        {
            if (Tables.ContainsKey(key))
            {
                var value = Tables[key];

                // Fix class skills
                if (key == "ModStr3a")
                {
                    value = value.Replace("Amazon", "%d");
                }

                return value;
            }

            if (!string.IsNullOrEmpty(key))
            {
                // ExceptionHandler.LogException(new System.Exception($"Could not find key '{key}' in any .tbl file"));
            }

            return null;
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
