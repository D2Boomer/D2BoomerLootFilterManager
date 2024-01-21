using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Boomer_TBL.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TblHashNode // node of the hash table in string *.tbl file
    {
        [FieldOffset(0x00)]
        public byte Active;          // +0x00 - shows if the entry is used. if 0, then it has been "deleted" from the table

        [FieldOffset(0x01)]
        public ushort Index;           // +0x01 - index in Indices array

        [FieldOffset(0x03)]
        public uint HashValue;       // +0x03 - hash value of the current string key

        [FieldOffset(0x07)]
        public uint StringKeyOffset; // +0x07 - offset of the current string key

        [FieldOffset(0x0B)]
        public uint StringValOffset; // +0x0B - offset of the current string value

        [FieldOffset(0x0F)]
        public ushort StringValLength; // +0x0F - length of the current string value

        public const int size = 0x11;
    };
}
