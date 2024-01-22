using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using D2BoomerLootFilterManager_UI.Forms;
using Lib_D2Data;
using Lib_D2Data.Dictionaries;
using Lib_D2Data.Equipment;
using Lib_D2Data.Items;
using Lib_D2Data.Types;

namespace D2BoomerLootFilterManager_UI.Forms.LoadFormMethods
{
    public class EquipmentForm_Load
    {
        public TreeNode tv_AllItems = new TreeNode("All Items");
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Dictionary<string, TreeNode> NodeDictionary = new Dictionary<string, TreeNode>();

        public Dictionary<string, string> CategoryDictionary = new Dictionary<string, string>
            {
                {"UNI", "Unique Items" },
                {"SET", "Set Items" },
                {"RW", "Runewords" },
                {"NMAG", "Normal Items" },
                {"MAG", "Magic Items" },
                {"ARMOR", "All - Armors" },
                {"WEAPON", "All - Weapons" },
                {"JEWELRY", "All - Jewelry and Charms" }
            };

        public TreeNode AddNode(TreeNode parent, string key, string value)
        {
            TreeNode newNode;
            if (NodeDictionary.ContainsKey(key.ToUpper()))
            {
                newNode = NodeDictionary[key.ToUpper()];
                Console.WriteLine("WARNING: NodeDict already contains: " + key.ToUpper());
            } 
            else
            {
                newNode = parent.Nodes.Add(key.ToUpper(), value);
                NodeDictionary.Add(key.ToUpper(), newNode);
            }

            return newNode;
        }

        public TreeNode GetNode(string key)
        {
            if (!NodeDictionary.ContainsKey(key.ToUpper())) Console.WriteLine("Key Not Found: " + key.ToUpper());
            return NodeDictionary[key.ToUpper()];
        }

        public EquipmentForm_Load()
        {
            // Max Props I found was 17 on Runewords
            foreach (Runeword rw in D2Data.Runewords)
            {
                if (rw.Name == "Enigma")
                {
                    foreach (ItemProperty prop in rw.Properties)
                    {
                        Console.WriteLine("Suffix: " + prop.Suffix);
                        Console.WriteLine("Parameter: " + prop.Parameter);
                        Console.WriteLine("Min: " + prop.Min);
                        Console.WriteLine("Max: " + prop.Max);
                        Console.WriteLine("Index: " + prop.Index);
                        Console.WriteLine("Compare Key: " + prop.CompareKey);
                        Console.WriteLine("Item Level: " + prop.ItemLevel);
                        Console.WriteLine("ItemStatCost: " + prop.ItemStatCost);
                        Console.WriteLine("Property: " + prop.Property);
                        Console.WriteLine("Property String: " + prop.PropertyString);
                        Console.WriteLine();
                    }
                }
            }



            // Helper Functions
            LoadClasses();
            IEnumerable<Unique> items = Enumerable.Empty<Unique>();

            // Item Categories
            AddNode(tv_AllItems, "UNI", "Unique Items");
            AddNode(tv_AllItems, "SET", "Set Items");
            AddNode(tv_AllItems, "RW", "Runewords");
            AddNode(tv_AllItems, "NMAG", "Normal Items");
            AddNode(tv_AllItems, "MAG", "Magic Items");

            // Load Unique Item Categories
            // AddNode(GetNode("UNI"), "CLASS", "All - Class Specific");
            AddNode(GetNode("UNI"), "ARMOR", "All - Armors");
            AddNode(GetNode("UNI"), "WEAPON", "All - Weapons");
            AddNode(GetNode("UNI"), "AMU,RIN,AQV,CQV", "All - Accessories");
            AddNode(GetNode("UNI"), "CM1,CM2,CM3", "All - Charms");
            AddNode(GetNode("UNI"), "JEW", "All - Jewels");
            AddNode(GetNode("UNI"), "MISC", "Other");

            // Insert Class sections into Class Specific -- [TODO:] This doesn't currently include all class specific unique items.
            /*
            foreach (var cl in Classes)
            {
                TreeNode newNode = AddNode(GetNode("CLASS"), cl.Key, cl.Value);
                items = Enumerable.Empty<Unique>();

                switch (cl.Value)
                {
                    case "Amazon": GetUniquesForClass("amaz", "ama", cl.Key, cl.Value); break;
                    case "Barbarian": GetUniquesForClass("barb", "bar", cl.Key, cl.Value); break;
                    case "Druid": GetUniquesForClass("drui", "dru", cl.Key, cl.Value); break;
                    case "Necromancer": GetUniquesForClass("necr", "nec", cl.Key, cl.Value); break;
                    case "Paladin": GetUniquesForClass("pala", "pal", cl.Key, cl.Value); break;
                    case "Sorceress": GetUniquesForClass("sorc", "sor", cl.Key, cl.Value); break;
                }
            }
            */

            // Insert Armors Sections


            AddNode(GetNode("ARMOR"), "Helm", "Helm");
            AddNode(GetNode("ARMOR"), "Chest", "Chest");
            AddNode(GetNode("ARMOR"), "Belt", "Belt");
            AddNode(GetNode("ARMOR"), "Glove", "Gloves");
            AddNode(GetNode("ARMOR"), "Boot", "Boots");
            AddNode(GetNode("ARMOR"), "Shield", "Shield");

            // Insert Armor Sections
            AddNode(GetNode("WEAPON"), "Axe", "Axes");
            AddNode(GetNode("WEAPON"), "Bow", "Bows");
            AddNode(GetNode("WEAPON"), "Claw", "Claw");
            AddNode(GetNode("WEAPON"), "Crossbow", "Crossbows");
            AddNode(GetNode("WEAPON"), "Dagger", "Daggers");
            AddNode(GetNode("WEAPON"), "Javelin", "Javelins");
            AddNode(GetNode("WEAPON"), "Mace", "Maces");
            AddNode(GetNode("WEAPON"), "Orb", "Orbs");
            AddNode(GetNode("WEAPON"), "Polearm", "Polearms");
            AddNode(GetNode("WEAPON"), "Scepter", "Scepters");
            AddNode(GetNode("WEAPON"), "Spear", "Spears");
            AddNode(GetNode("WEAPON"), "Stave", "Staves");
            AddNode(GetNode("WEAPON"), "Sword", "Swords");
            AddNode(GetNode("WEAPON"), "Throwing Weapon", "Throwing Weapons");
            AddNode(GetNode("WEAPON"), "Wand", "Wands");

            // Insert Accessories Section
            AddNode(GetNode("AMU,RIN,AQV,CQV"), "Amulet", "Amulets");
            AddNode(GetNode("AMU,RIN,AQV,CQV"), "Bolt", "Bolts");
            AddNode(GetNode("AMU,RIN,AQV,CQV"), "Ring", "Rings");
            AddNode(GetNode("AMU,RIN,AQV,CQV"), "Quiver", "Quivers");

            // Inserts Charms Section
            AddNode(GetNode("CM1,CM2,CM3"), "SmallCharm", "Small Charms");
            AddNode(GetNode("CM1,CM2,CM3"), "LargeCharm", "Large Charms");
            AddNode(GetNode("CM1,CM2,CM3"), "GrandCharm", "Grand Charms");

            // Insert Jewels Section
            AddNode(GetNode("JEW"), "Jewel", "Jewels");

            // Insert Misc Section
            AddNode(GetNode("MISC"), "Jewel", "Jewels");


            foreach (Unique uniq in D2Data.Uniques)
            {
                var newCat = TranslateTypeToCategory(uniq.Type);

                if (uniq.Name == "Iceblink")
                {
                    Console.WriteLine("Iceblink - Code [" + uniq.Code + "] Category: " + newCat);
                }

                if (newCat != String.Empty) AddNode(GetNode(newCat), uniq.Code, uniq.Name);
            }
        }

        private string TranslateTypeToCategory(string type)
        {
            switch (type)
            {
                case "Amazon Bow":          return "Bow";
                case "Amazon Javelin":      return "Javelin";
                case "Amazon Spear":        return "Spear"; 
                case "Amulet":              return "Amulet";
                case "Amulet [S]":          return "Amulet";
                case "Armor":               return "Chest"; 
                case "Auric Shields":       return "Shield";
                case "Axe":                 return "Axe";
                case "Belt":                return "Belt"; 
                case "Belt [S]":            return "Belt"; 
                case "Boots":               return "Boot";
                case "Bow":                 return "Bow"; 
                case "Circlet":             return "Helm";
                case "Club":                return "Mace";
                case "Crossbow":            return "Crossbow"; 
                case "Gloves":              return "Glove"; 
                case "Hammer":              return "Mace"; 
                case "Hand to Hand":        return "Claw"; 
                case "Hand to Hand 2":      return "Claw"; 
                case "Helm":                return "Helm"; 
                case "Javelin":             return "Javelin"; 
                case "Jewel":               return "Jewel"; 
                case "Knife":               return "Dagger"; 
                case "Large Charm":         return "GrandCharm"; 
                case "Mace":                return "Mace"; 
                case "Map T5":              return "Misc"; 
                case "Medium Charm":        return "LargeCharm"; 
                case "Orb":                 return "Orb"; 
                case "Pelt":                return "Helm"; 
                case "Polearm":             return "Polearm"; 
                case "Primal Helm":         return "Helm"; 
                case "Ring":                return "Ring"; 
                case "Scepter":             return "Scepter"; 
                case "Scythe Type":         return "Mace"; 
                case "Shield":              return "Shield"; 
                case "Small Charm":         return "SmallCharm"; 
                case "Spear":               return "Spear"; 
                case "Staff":               return "Stave"; 
                case "Sword":               return "Sword"; 
                case "Throwing Axe":        return "Throwing Weapon"; 
                case "Throwing Knife":      return "Throwing Weapon"; 
                case "Voodoo Heads":        return "Shield"; 
                case "Wand":                return "Wand"; 
            }

            return String.Empty;
        }

        private void GetUniquesForClass(string equiv, string prop, string classKey, string classValue)
        {
            IEnumerable<Unique> items = from unique in D2Data.Uniques where unique.Equipment.Type.Equiv2 == equiv || unique.Equipment.Type.Equiv1 == equiv select unique;
            IEnumerable<Unique> items2  = from unique in D2Data.Uniques 
                                          where unique.Prop1 == prop || 
                                                unique.Prop2 == prop ||
                                                unique.Prop3 == prop ||
                                                unique.Prop4 == prop
                                          select unique;
            TreeNode newNode = AddNode(GetNode("CLASS"), classKey, classValue);

            foreach (Unique item in items.Distinct())
            {
                AddNode(newNode, item.Code, item.Name);
            }

            foreach (Unique item in items2.Distinct())
            {
                AddNode(newNode, item.Code, item.Name);
            }
        }

        private void LoadClasses()
        {
            foreach (var cl in CharStat.AllClasses)
            {
                switch (cl)
                {
                    case "Amazon":  Classes.Add("ZON", cl); break;
                    case "Assassin": Classes.Add("SIN", cl); break;
                    case "Barbarian": Classes.Add("BAR", cl); break;
                    case "Druid": Classes.Add("DRU", cl); break;
                    case "Necromancer": Classes.Add("NEC", cl); break;
                    case "Paladin": Classes.Add("DIN", cl); break;
                    case "Sorceress": Classes.Add("SOR", cl); break;
                }
            }
        }

    }
}
