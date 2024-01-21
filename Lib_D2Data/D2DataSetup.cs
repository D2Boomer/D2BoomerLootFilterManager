using System;
using System.IO;

namespace Lib_D2Data
{
    public class D2DataSetup
    {
        public string excelDirectory;
        public string tableDirectory;
        public string outputDirectory;
        public D2DataSetup()
        {
            Directory.CreateDirectory(AppContext.BaseDirectory + @"ExcelPath");
            Directory.CreateDirectory(AppContext.BaseDirectory + @"TablePath");
            Directory.CreateDirectory(AppContext.BaseDirectory + @"OutputPath");

            excelDirectory = AppContext.BaseDirectory + @"ExcelPath";
            tableDirectory = AppContext.BaseDirectory + @"TablePath";
            outputDirectory = AppContext.BaseDirectory + @"OutputPath";
        }
    }
}
