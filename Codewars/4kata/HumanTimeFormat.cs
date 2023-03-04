using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars._4kata
{

    /// <summary>
    /// 4 Human readable duration format
    /// https://www.codewars.com/kata/52742f58faf5485cae000b9a/train/csharp
    /// </summary>
    public class HumanTimeFormat
    {
        public static string formatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";


            int year = seconds / 60 / 60 / 24 / 365;

            seconds -= (year * 365 * 24 * 60 * 60);

            int days = seconds / 60 / 60 / 24;

            seconds -= (days * 24 * 60 * 60);

            int hours = seconds / 60 / 60;

            seconds -= (hours * 60 * 60);

            int minutes = seconds / 60;

            seconds -= (minutes * 60);

            List<string> date = new List<string>();

            if (year > 0)
                date.Add(FormatYear(year));

            if (days > 0)
                date.Add(FormatDay(days));

            if (hours > 0)
                date.Add(FormatHour(hours));

            if (minutes > 0)
                date.Add(FormatMinute(minutes));

            if (seconds > 0)
                date.Add(FormatSecond(seconds));


            if(date.Count == 1)
            {
                return date[0];
            }

            string format = "";

            if (date.Count > 2)
            {
                for (int i = 0; i < date.Count - 2; i++)
                {
                    format += date[i] + ", ";
                }
            }

            format += date[date.Count - 2] + " and " + date[date.Count - 1];


            return format;
        }

        public static string FormatSecond(int number)
        {
            if (number == 1)
                return "1 second";

            return number + " seconds";
        }

        public static string FormatMinute(int number)
        {
            if (number == 1)
                return "1 minute";

            return number + " minutes";
        }

        public static string FormatHour(int number)
        {
            if (number == 1)
                return "1 hour";

            return number + " hours";
        }

        public static string FormatDay(int number)
        {
            if(number == 1)
                return "1 day";

            return number + " days";
        }

        public static string FormatYear(int number)
        {
            if (number == 1)
                return "1 year";

            return number + " years";
        }
    }
}
