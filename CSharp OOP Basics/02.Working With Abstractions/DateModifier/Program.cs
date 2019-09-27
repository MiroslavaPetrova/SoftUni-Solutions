using System;

namespace DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.CalculateDaysDifference(date1, date2));
        }
    }
}
