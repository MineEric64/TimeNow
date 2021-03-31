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
        public RegionInfo Country { get; }
        public DateTime Now { get; }

        public string CountryName { get; }
        public string APM { get; }
        public string Time { get; }
        public string Date { get; }

        public TimeInfo(RegionInfo country, DateTime now)
        {
            Country = country;
            Now = now;

            CountryName = country.NativeName; //Seoul
            APM = now.ToString("tt"); //AM
            Time = now.ToString("hh:mm:ss"); //09:00:00
            Date = now.ToString(CultureInfo.InvariantCulture); //01/01/21 Wed.
        }
    }
}
