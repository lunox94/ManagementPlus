using System;

namespace ManagementPlus.Extensions
{
    public static class LongExtensions
    {
        public static string ToStringFromTimeSpanTicks(this long value)
        {
            var timeSpan = new TimeSpan(value);
            return $"{Math.Floor(timeSpan.TotalHours)}:{timeSpan.Minutes}{(timeSpan.Minutes < 10 ? "0" : "")}";
        }
    }
}
