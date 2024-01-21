using D2Boomer_AppSettings;
using System;
using System.IO;

namespace D2Boomer_MPQLibrary
{
    public static class MPQSetup
    {
        public static void Begin()
        {
            if (!CheckTxtFiles()) ExtractTxtFiles();
            if (!CheckTblFiles()) ExtractTblFiles();
        }

        public static bool CheckTblFiles()
        {
            string[] RequiredTblFiles = {
                "d2data_string.tbl", 
                "patch_d2_patchstring.tbl",
                "d2exp_patchstring.tbl", 
                "d2exp_expansionstring.tbl",
                "pd2_pd2data_string.tbl",
                "pd2_pd2data_patchstring.tbl",
                "pd2_pd2data_expansionstring.tbl",
                "pd2_patch_d2_patchstring.tbl",
                "d2data_beta_string.tbl"
            };

            Console.WriteLine("Outputs going here: " + AppContext.BaseDirectory);

            DirectoryInfo dir = Directory.CreateDirectory(AppContext.BaseDirectory + @"TablePath");
            FileInfo[] files = dir.GetFiles("*.tbl");

            if (files.Length != RequiredTblFiles.Length)
            {
                return false;
            }

            return true;
        }

        public static void ExtractTblFiles(string lng = "ENG")
        {
            MPQ d2Data = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"d2data.mpq");
            MPQ patch_d2 = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"patch_d2.mpq");
            MPQ d2exp = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"d2exp.mpq");

            MPQ PD2_d2Data = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"ProjectD2\pd2data.mpq");
            MPQ PD2_patch_d2 = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"ProjectD2\patch_d2.mpq");

            d2Data.ExtractFile(@"data\local\lng\" + lng + @"\string.tbl", AppContext.BaseDirectory + @"TablePath" + @"\d2data_string.tbl");
            d2Data.ExtractFile(@"data\local\lng\eng\BETA\string.tbl", AppContext.BaseDirectory + @"TablePath" + @"\d2data_beta_string.tbl");

            patch_d2.ExtractFile(@"data\local\lng\" + lng + @"\patchstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\patch_d2_patchstring.tbl");
            d2exp.ExtractFile(@"data\local\lng\" + lng + @"\patchstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\d2exp_patchstring.tbl");
            d2exp.ExtractFile(@"data\local\lng\" + lng + @"\expansionstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\d2exp_expansionstring.tbl");

            PD2_d2Data.ExtractFile(@"data\local\lng\" + lng + @"\string.tbl", AppContext.BaseDirectory + @"TablePath" + @"\pd2_pd2data_string.tbl");
            PD2_d2Data.ExtractFile(@"data\local\lng\" + lng + @"\patchstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\pd2_pd2data_patchstring.tbl");
            PD2_d2Data.ExtractFile(@"data\local\lng\" + lng + @"\expansionstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\pd2_pd2data_expansionstring.tbl");
            PD2_patch_d2.ExtractFile(@"data\local\lng\" + lng + @"\patchstring.tbl", AppContext.BaseDirectory + @"TablePath" + @"\pd2_patch_d2_patchstring.tbl");
        }

        public static bool CheckTxtFiles()
        {
            DirectoryInfo dir = Directory.CreateDirectory(AppContext.BaseDirectory + @"ExcelPath");
            FileInfo[] files = dir.GetFiles("*.txt");

            if (files.Length != D2B_Settings.GetSetting("RequiredTxtFiles").Length)
            {
                return false;
            }

            return true;
        }

        public static void ExtractTxtFiles()
        {
            MPQ PD2 = new MPQ(D2B_Settings.GetSetting("Diablo2_Path") + @"ProjectD2\pd2data.mpq");

            foreach (string filename in D2B_Settings.GetSettingCollection("RequiredTxtFiles"))
            {
                PD2.ExtractFile(@"data\global\excel\" + filename + ".txt", AppContext.BaseDirectory + @"ExcelPath" + @"\" + filename + ".txt");
            }
        }
    }
}
