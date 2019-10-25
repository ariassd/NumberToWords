using System;
using System.Globalization;

namespace NumberToWords
{
    public static class DateToWords
    {
        public static string ToWords(this DateTime date, DateFormat format = DateFormat.dayName_day_month_year)
        {
            decimal day = date.Day;
            decimal year = date.Year;
            var str = date.ToString(DateToWordsResources.ResourceManager.GetString(format.ToString()), CultureInfo.CreateSpecificCulture("es-CR"));
            return str.Replace("__#__", day.ToWords(false)).Replace("__*__", year.ToWords(false));
        }

        public enum DateFormat
        {
            dayName_day_month_year,
            dayName_day_month,
            day_month_year,
            day_month,
            month_year
        }
    }
}
