using System.Collections.Generic;

namespace D2BoomerLootFilterManager_UI.Models
{
    public class tvNode
    {
        public string Description;
        public string Code;
        public List<tvNode> Children;

        public tvNode(string desc)
        {
            Description = desc;
            Children = new List<tvNode>();
        }

        public tvNode(string code, string desc)
        {
            Description = desc;
            Code = code;
            Children = new List<tvNode>();
        }
    }
}
