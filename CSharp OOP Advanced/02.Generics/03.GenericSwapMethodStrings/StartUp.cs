using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> lines = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                lines.Add(line);
            }
            Box<string> box = new Box<string>(lines);

            int [] indexesToSwap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstIndex = indexesToSwap[0];
            int secondIndex = indexesToSwap[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
