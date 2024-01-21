using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Boomer_TBL.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TblHeader
    {
        [FieldOffset(0x00)]
        public ushort CRC;             // +0x00 - CRC value for string table

        [FieldOffset(0x02)]
        public ushort NodesNumber;     // +0x02 - size of Indices array

        [FieldOffset(0x04)]
        public uint HashTableSize;   // +0x04 - size of TblHashNode array

        [FieldOffset(0x08)]
        public byte Version;         // +0x08 - file version, either 0 or 1, doesn't matter

        [FieldOffset(0x09)]
        public uint DataStartOffset; // +0x09 - string table start offset

        [FieldOffset(0x0D)]
        public uint HashMaxTries;    // +0x0D - max number of collisions for string key search based on its hash value

        [FieldOffset(0x011)]
        public uint FileSize;        // +0x11 - size of the file

        public const int size = 0x15;
    };
}
