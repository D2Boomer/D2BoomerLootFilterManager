using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Boomer_TBL.Structs
{
    public struct TableList
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }

        public override string ToString()
        {
            return Key;
        }
    };
}
