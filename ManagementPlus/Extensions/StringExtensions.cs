using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Extensions
{
    public static class StringExtensions
    {
        public static long ToTimeSpanTicks(this string value)
        {
            var parsedTimeSpan = value.Split(':');
            var hours = int.Parse(parsedTimeSpan[0]);
            var minutes = parsedTimeSpan.Length > 1 ? int.Parse(parsedTimeSpan[1]) : 0;
            return new TimeSpan(hours, minutes, 0).Ticks;
        }
    }
}
