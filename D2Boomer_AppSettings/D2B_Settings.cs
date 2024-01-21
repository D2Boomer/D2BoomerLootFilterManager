using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Boomer_AppSettings
{
    public static class D2B_Settings
    {
        public static StringCollection GetSettingCollection(string key)
        {
            return (StringCollection)Properties.Settings.Default[key];
        }
        public static string GetSetting(string key)
        {
            return Properties.Settings.Default[key].ToString();
        }

        public static string SetSetting(string key, string value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
            return GetSetting(key);
        }
    }
}
