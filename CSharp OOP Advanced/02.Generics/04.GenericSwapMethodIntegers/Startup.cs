using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }
            Box<int> box = new Box<int>(numbers);

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];

            box.Swap(index1, index2);

            Console.WriteLine(box);
        }
    }
}
