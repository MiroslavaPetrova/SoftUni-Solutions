using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList list = new RandomList();

            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");


            Console.WriteLine(list.GetRandomElement());
            
        }
    }
}
