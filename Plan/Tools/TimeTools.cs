namespace Plan.Tools
{
    using System;

    public static class TimeTools
    {
        public static TimeSpan ToTimeSpan(this string s)
        {
            var timeArray = s.Replace(" ", string.Empty).Replace("O", "0").Replace("o", "0").Split(':');          
            var hours = Convert.ToInt32(timeArray[0]);
            var minutes = timeArray.Length == 2 ? Convert.ToInt32(timeArray[1]) : 0;
            return new TimeSpan(hours, minutes, 0);
        }
    }
}
