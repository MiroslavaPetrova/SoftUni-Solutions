using System;

namespace GenericBoxOofInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                int item = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(item);

                Console.WriteLine(box);
            }
        }
    }
}
