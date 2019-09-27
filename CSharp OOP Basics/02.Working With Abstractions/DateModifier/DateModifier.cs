using System;
using System.Globalization;

namespace DateModifier
{
    public class DateModifier
    {
        public static int CalculateDaysDifference(string date1, string date2)
        {
            DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

            return Math.Abs((firstDate - secondDate).Days);
        }
    }
}
