using Lib_D2Boomer_TBL.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_D2Boomer_TBL
{
    public class TableProcessor
    {
        private string _tblPath;
        public TableProcessor(string tblPath)
        {
            _tblPath = tblPath.Trim('/', '\\');
        }

        public static Dictionary<string, string> ReadTablesFile(string path)
        {
            var result = new Dictionary<string, string>();

            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var br = new BinaryReader(fs, Encoding.UTF8))
                {
                    var header = GetHeader(br); // Read the header
                    var numElem = header.FileSize - TblHeader.size; // number of bytes to read without header

                    // Check we can read the entire file
                    var byteArray = br.ReadBytes((int)numElem);
                    if (byteArray.Length == numElem)
                    {
                        br.BaseStream.Position = TblHeader.size;
                        result = GetStringTable(br, header); // Read the table
                    }
                    else
                    {
                        throw new Exception($"Table '{path}' seems to be corrupt");
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, string> GetStringTable(BinaryReader br, TblHeader header)
        {
            var result = new Dictionary<string, string>();
            var tableList = new List<TableList>();

            br.BaseStream.Position += header.NodesNumber * sizeof(ushort);
            var hashNodes = new List<TblHashNode>();

            for (uint i = 0; i < header.HashTableSize; i++)
            {
                hashNodes.Add(GetHashNode(br));
            }

            br.BaseStream.Position = 0;

            var byteArray = ReadAllBytes(br);
            foreach (var hashNode in hashNodes)
            {

                if (hashNode.Active == 0)
                {
                    continue;
                }
                else if (hashNode.Active != 1)
                {
                    continue;
                }

                string val = null;
                string key;

                val = Encoding.UTF8.GetString(byteArray, (int)hashNode.StringValOffset, hashNode.StringValLength).Trim('\0');
                key = Encoding.UTF8.GetString(byteArray, (int)hashNode.StringKeyOffset, (int)hashNode.StringValOffset - (int)hashNode.StringKeyOffset).Trim('\0');

                tableList.Add(new TableList { Key = key, Value = val ?? "", Index = hashNode.Index });
            }

            tableList = tableList.OrderBy(x => x.Index).ToList();

            foreach (var tableValue in tableList)
            {
                result[tableValue.Key] = tableValue.Value;
            }

            return result;
        }

        private static TblHeader GetHeader(BinaryReader br)
        {
            byte[] readBuffer = new byte[TblHeader.size];

            readBuffer = br.ReadBytes(TblHeader.size);
            GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            var header = (TblHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TblHeader));
            handle.Free();

            return header;
        }

        private static TblHashNode GetHashNode(BinaryReader br)
        {
            byte[] readBuffer = new byte[TblHashNode.size];

            readBuffer = br.ReadBytes(TblHashNode.size);
            GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            var result = (TblHashNode)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TblHashNode));
            handle.Free();

            return result;
        }

        private static byte[] ReadAllBytes(BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    ms.Write(buffer, 0, count);
                }
                return ms.ToArray();
            }
        }
    }
}
