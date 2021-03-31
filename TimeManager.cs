using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace TimeNow
{
    public class TimeManager
    {
        private static MainWindow _mainWindow;
        private static DispatcherTimer _timer = new DispatcherTimer();

        public static void Initialize(MainWindow main)
        {
            _mainWindow = main;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += OnUpdate;

            _timer.Start();
        }

        public static TimeInfo Update()
        {
            return new TimeInfo(RegionInfo.CurrentRegion, DateTime.Now);
        }

        private static void OnUpdate(object sender, EventArgs e)
        {
            TimeInfo now = Update();

            _mainWindow.xTime.Content = now.Time;
        }
    }
}
