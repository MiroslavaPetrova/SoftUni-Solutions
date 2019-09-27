namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class Box<T> where T : IComparable
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }

        public List<T> Items { get; set; }

        public int CompareTo(List<T> items, T element) 
        {
            int count = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
