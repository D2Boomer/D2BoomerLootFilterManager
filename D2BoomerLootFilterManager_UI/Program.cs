using D2Boomer_MPQLibrary;
using Lib_D2Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2BoomerLootFilterManager_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MPQSetup.Begin();
            D2Data.LoadIfNotLoaded();

            // D2Data.Uniques.First().

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainMenu());
            
        }
    }
}
