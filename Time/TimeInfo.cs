using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNow.Time
{
    public class TimeInfo
    {
        public DateTime Now { get; }

        public string APM { get; }
        public string Time { get; }
        public string Date { get; }

        public TimeInfo(DateTime now, CultureInfo cultureInfo)
        {
            Now = now;

            APM = now.ToString("tt", cultureInfo); //AM
            Time = now.ToString("h:mm:ss", cultureInfo); //9:00:00
            Date = now.ToString("D", cultureInfo); //01/01/21 Wed
        }
    }
}
