using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;

using TimeNow.Settings;

namespace TimeNow.Time
{
    public class TimeManager
    {
        public static event EventHandler<TimeInfo> OnUpdated;
        private static DispatcherTimer _timer = new DispatcherTimer();

        public static void Initialize()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += OnUpdate;

            _timer.Start();
        }

        public static TimeInfo Update()
        {
            return new TimeInfo(DateTime.Now, SettingsManager.CurrentCulture);
        }

        private static void OnUpdate(object sender, EventArgs e)
        {
            TimeInfo info = Update();
            OnUpdated?.Invoke(null, info);
        }
    }
}
