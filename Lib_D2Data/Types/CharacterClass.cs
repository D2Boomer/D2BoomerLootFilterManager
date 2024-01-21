using Lib_D2Data.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Data.Types
{
    public class CharacterClass
    {
        public static List<CharacterClass> All = new List<CharacterClass>();
        public string ClassName { get; set; }

        public static Dictionary<string, string> BodyLocs = new Dictionary<string, string>
        {
            [""] = "None",
            ["head"] = "Head",
            ["neck"] = "Neck",
            ["tors"] = "Torso",
            ["rarm"] = "Right Arm",
            ["larm"] = "Left Arm",
            ["rrin"] = "Right Ring",
            ["lrin"] = "Left Ring",
            ["belt"] = "Belt",
            ["feet"] = "Feet",
            ["glov"] = "Gloves"
        };

        public CharacterClass()
        {
            Console.WriteLine("Character Class was just added: " + this.ClassName);
            All.Add(this);
        }

        public CharacterClass(string className)
        {
            Console.WriteLine("Character Class was just added: " + this.ClassName);
            ClassName = className;
            All.Add(this);
        }

        public static void Import()
        {
            Console.WriteLine("CharacterClass Import Called");
            foreach (KeyValuePair<string, CharStat> charStat in CharStat.CharStats)
            {
                Console.WriteLine("New Class: " + charStat.Value.Class);
                CharacterClass newClass = new CharacterClass(charStat.Value.Class);
            }
        }

    }
}
