using Lib_D2Data.Dictionaries;
using Lib_D2Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2BoomerLootFilterManager_UI.Models
{
    public class UniqueItems_TreeView
    {
        public tvNode ClassOnlyItems = new tvNode("Class Specific Items");
        public tvNode Armor = new tvNode("Armor");
        public tvNode Weapons = new tvNode("Weapons");
        public tvNode Accessories = new tvNode("Accessories");
        public tvNode Charms = new tvNode("Charms");
        public tvNode Jewels = new tvNode("Jewels");

        public List<tvNode> ParentNodes = new List<tvNode>();

        public UniqueItems_TreeView()
        {
            // CharacterClass.All                               // string[] Classes = { "Amazon", "Assassin", "Barbarian", "Druid", "Necromancer", "Paladin", "Sorceress" };
            // CharacterClass.BodyLocs                          // string[] Armors = { "Head", "Chest", "Belt", "Gloves", "Boots", "Shield" };
            // Weapon.WeaponTypes.Values.Distinct().ToList()    // string[] Weapons = { "Axes", "Maces", "Swords", "Daggers", "Throwing Weapons", "Javelins", "Spears", "Polearms", "Bows", "Crossbows", "Staves", "Wands", "Scepters" };
            // Misc.MiscAccessories                             // string[] Accessories = { "Amulets", "Rings", "Quivers", "Bolts" };
            // Misc.MiscCharms                                  // string[] Charms = { "Grand Charms" };
            // Misc.MiscJewels                                  // string[] Jewels = { "Jewels" };


            foreach (var cl in CharStat.AllClasses)
            {
                ClassOnlyItems.Children.Add(new tvNode(cl));
            }
            ParentNodes.Add(ClassOnlyItems);

            ParentNodes.Add(Armor);
            ParentNodes.Add(Weapons);
            ParentNodes.Add(Accessories);
            ParentNodes.Add(Charms);
            ParentNodes.Add(Jewels);

        }
    }
}
