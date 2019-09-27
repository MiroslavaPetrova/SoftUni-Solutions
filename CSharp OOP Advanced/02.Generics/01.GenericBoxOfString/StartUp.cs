using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                string value = Console.ReadLine();

                Box<string> box = new Box<string>(value);

                Console.WriteLine(box);
            }
        }
    }
}
