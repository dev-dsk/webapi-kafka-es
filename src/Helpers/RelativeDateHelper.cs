namespace Permissions.API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RelativeDateHelper
    {
        private static Dictionary<double, Func<double, string>>? sm_Dict = null;

        private static Dictionary<double, Func<double, string>> DictionarySetup()
        {
            var dict = new Dictionary<double, Func<double, string>>
            {
                { 0.75, (mins) => "less than a minute" },
                { 1.5, (mins) => "about a minute" },
                { 45, (mins) => string.Format("{0} minutes", Math.Round(mins)) },
                { 90, (mins) => "about an hour" },
                { 1440, (mins) => string.Format("about {0} hours", Math.Round(Math.Abs(mins / 60))) }, // 60 * 24
                { 2880, (mins) => "a day" }, // 60 * 48
                { 43200, (mins) => string.Format("{0} days", Math.Floor(Math.Abs(mins / 1440))) }, // 60 * 24 * 30
                { 86400, (mins) => "about a month" }, // 60 * 24 * 60
                { 525600, (mins) => string.Format("{0} months", Math.Floor(Math.Abs(mins / 43200))) }, // 60 * 24 * 365 
                { 1051200, (mins) => "about a year" }, // 60 * 24 * 365 * 2
                { double.MaxValue, (mins) => string.Format("{0} years", Math.Floor(Math.Abs(mins / 525600))) }
            };

            return dict;
        }

        public static string ToRelativeDate(this DateTime input)
        {
            TimeSpan oSpan = DateTime.Now.Subtract(input);
            double TotalMinutes = oSpan.TotalMinutes;
            string Suffix = " ago";

            if (TotalMinutes < 0.0)
            {
                TotalMinutes = Math.Abs(TotalMinutes);
                Suffix = " from now";
            }

            if (null == sm_Dict)
                sm_Dict = DictionarySetup();

            return sm_Dict.First(n => TotalMinutes < n.Key).Value.Invoke(TotalMinutes) + Suffix;
        }
    }
}
