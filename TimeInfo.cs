using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNow
{
    public class TimeInfo
    {
        public DateTime Now { get; }

        public string APM { get; }
        public string Time { get; }
        public string Date { get; }

        public TimeInfo(DateTime now)
        {
            Now = now;

            APM = now.ToString("tt"); //AM
            Time = now.ToString("hh:mm:ss"); //09:00:00
            Date = now.ToLongDateString(); //01/01/21 Wed
        }
    }
}
