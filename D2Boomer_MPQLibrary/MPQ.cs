using D2Boomer_MPQLibrary.Storm;
using System;
using System.IO;

namespace D2Boomer_MPQLibrary
{
    public class MPQ
    {
        private string _mpqPath;
        private IntPtr handle;
        private bool ArchiveIsOpen = false;
        public MPQ(string mpqPath)
        {
            _mpqPath = mpqPath.Trim('/', '\\');
        }

        public void OpenArchive()
        {
            if (!File.Exists(_mpqPath)) throw new FileNotFoundException(_mpqPath);
            if (!StormLib.SFileOpenArchive(_mpqPath, 0, OpenArchiveFlags.READ_ONLY, out handle)) throw new IOException("SFileOpenArchive failed");
        }

        public bool ExtractFile(string fileName, string outputFile)
        {
            if (!ArchiveIsOpen) OpenArchive();
            return StormLib.SFileExtractFile(handle, fileName, outputFile, 0x00000000);
        }

        public bool HasFile(string fileName)
        {
            return StormLib.SFileHasFile(handle, fileName);
        }
    }
}
