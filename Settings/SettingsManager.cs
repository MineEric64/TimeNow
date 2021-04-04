using System;
using System.Globalization;
using System.Threading;

namespace TimeNow.Settings
{
    public class SettingsManager
    {
        public static CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentCulture;

        public static Properties.Settings Default => Properties.Settings.Default;

        public static void Load()
        {
            if (Default.CurrentCulture != "default")
            {
                CurrentCulture = new CultureInfo(Default.CurrentCulture);
                Thread.CurrentThread.CurrentCulture = CurrentCulture;
            }
        }

        public static void Save()
        {
            if (Default.CurrentCulture != "default")
            {
                Default.CurrentCulture = CurrentCulture.Name;
            }

            Default.Save();
        }

        public static void Apply()
        {
            Save();
            Load();
        }
    }
}