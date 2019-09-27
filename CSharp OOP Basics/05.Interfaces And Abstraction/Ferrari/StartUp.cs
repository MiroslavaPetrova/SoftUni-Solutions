using System;

namespace Ferrari
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driver);

            Console.WriteLine($"{ferrari.Model}/{ferrari.PushBrakes()}" +
                $"/{ferrari.PushGasPedal()}/{ferrari.Driver}");
        }
    }
}
