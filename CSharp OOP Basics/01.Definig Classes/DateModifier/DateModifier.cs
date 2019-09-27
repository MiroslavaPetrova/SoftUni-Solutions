using System;
using System.Globalization;

namespace DateModifier
{
    public class DateModifier
    {
        public static int CalculateDifference(string firstDate, string secondDate)
        {
            DateTime date1 = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
