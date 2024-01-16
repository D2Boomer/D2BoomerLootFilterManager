using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Boomer_AppSettings
{
    public static class D2B_Settings
    {
        public static string GetUserSetting(string key)
        {
            return Properties.Settings.Default[key].ToString();
        }

        public static string SetUserSetting(string key, string value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
            return GetUserSetting(key);
        }
    }
}
