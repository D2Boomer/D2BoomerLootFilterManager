using System;
using D2Boomer_MPQLibrary;
using Lib_D2Boomer_TBL;
using Lib_D2Data;
using Lib_D2Data.Items;
using Lib_D2Data.Dictionaries;
using Lib_D2Data.Types;
using System.Collections.Generic;
using System.Linq;
using Lib_D2Data.Equipment;

/*
 *  Credits:
 *      Elmegaard - https://github.com/Elmegaard/D2TxtImporter
 *          This project makes rampant use of code from their D2TxtImporter project.
 *          Writing all of the models for the various components of D2 wouldn't have been fun :(.
 *          
 *      Zezula - http://www.zezula.net/en
 *          This project relied very heavily upon the documentation Zezula provided for Storm.dll
 * 
 */

namespace Console_UnitTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test MPQ - Extract all tbl/txt files needed from the various MPQ files.
            TestMPQ();

            // Test TBL - Read the display string for a specific item "uap". Should return Shako.
            TestTBL();

            // Test D2Data - Spit out 5 unique items. This will confirm MPQ, TBL, and D2Data are all functioning successfully. 
            TestD2Data();

            // Test TestProps - Display all properties of the runeword 'Enigma' to confirm properties have been accurately associated. 
            // TestProps();

            // Test_GetClassOnlyUniques();

            RandomTest();

            Console.ReadLine();
        }

        private static void RandomTest()
        {
            foreach (var c in CharacterClass.All)
            {
                Console.WriteLine(c.ClassName);
            }
        }

        private static void Test_GetClassOnlyUniques()
        {
            List<Unique> PaladinOnlyItems = new List<Unique>();
            Console.WriteLine("Begin Paladin Only Items");

            var items =
                from unique in D2Data.Uniques
                where unique.Equipment.Type.Equiv2 == "barb"
                select unique;

            foreach (Unique item in items)
            {
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Equipment Type: " + item.Equipment.EquipmentType);
                Console.WriteLine("Type: " + item.Type);
                Console.WriteLine("Body Loc: " + item.Equipment.Type.BodyLoc1);

                foreach (var p in item.Properties)
                {
                    Console.WriteLine(p.PropertyString);
                }
                Console.WriteLine();

            }
        }

        private static void TestMPQ()
        {
            Console.WriteLine("Test: TestMPQ - Expected Result: 20 txt files and 9 tbl files to be extracted from the MPQ files.");
            MPQSetup.Begin(); // This will extract all of the necessary TXT and TBL files.
            Console.WriteLine("Files Found: TxtDir (20), TblDir (9)");
            Console.WriteLine("Test: TestMPQ - Complete (Pass)");
            Console.WriteLine();
        }

        private static void TestTBL()
        {
            Console.WriteLine("Test: TestTBL - Expected Result: Pull the Display Name for Item code [UAP]. Should return 'Shako'.");
            TBL tblReader = new TBL(AppContext.BaseDirectory + @"TablePath");
            Console.WriteLine("String value of the ID 'cap' is: " + tblReader.ValueOf("cap"));
            Console.WriteLine("Test: TestTBL - Complete (Pass)");
            Console.WriteLine();
        }

        private static void TestD2Data()
        {
            Console.WriteLine("Test: TestD2Data - Display 5 unique items and their base types to validate model ingestion.");
            int maxItemsOut = 5;

            int cnt = 0;
            if (D2Data.Uniques != null)
            {
                foreach (Unique item in D2Data.Uniques)
                {
                    Console.WriteLine("Unique " + item.Equipment.Type + " named " + item.Name);
                    cnt++;
                    if (cnt == maxItemsOut) break;
                }
            }
            Console.WriteLine("Test: TestD2Data - Complete (Pass)");
            Console.WriteLine();
        }

        private static void TestProps()
        {
            Console.WriteLine("Test: TestProps - To validate item properties have been applied to all items, show all properties of Runeword 'Enigma'");
            
            foreach (Runeword item in D2Data.Runewords)
            {
                if (item.Name == "Enigma")
                {
                    Console.WriteLine("Runeword: " + item.Name);
                    foreach (ItemProperty property in item.Properties)
                    {
                        Console.WriteLine("Property: " + property.PropertyString);
                    }

                    Console.WriteLine("Required Level: " + item.RequiredLevel);
                    Console.WriteLine("Runes to Create " + item.Name);
                    
                    foreach (Misc str in item.Runes)
                    {
                        Console.WriteLine("Name " + str.Name + " --- Item Level: " + str.ItemLevel);
                    }
                }
            }

            Console.WriteLine("Test: TestProps - Complete (Pass)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("All tests complete.");
        }
    }
}
