using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random randomGenerator;

        public RandomList()
        {
            randomGenerator = new Random();
        }

        public string GetRandomElement()
        {
            var index = randomGenerator.Next(0, Count - 1);
            string result = this[index];
            RemoveAt(index);

            return result;
        }
    }
}
