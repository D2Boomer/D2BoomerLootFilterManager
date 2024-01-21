using Lib_D2Boomer_TBL.Dictionaries;
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
    public class TBL
    {
        private string _tblPath = string.Empty;
        private bool _isLoaded = false;
        private Dictionary<string, string> _loadedData;

        public TBL(string tblPath)
        {
            _tblPath = tblPath;
        }

        public string ValueOf(string key)
        {
            return LoadIfNotLoaded().GetAllData()[key];
        }

        public Dictionary<string, string> GetAllData()
        {
            return _loadedData;
        }

        public TBL LoadIfNotLoaded()
        {
            if (!_isLoaded) LoadData();
            return this;
        }

        public TBL LoadData()
        {
            try
            {
                _loadedData = Table.ImportFromTbl(_tblPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return this;
        }
    }
}
