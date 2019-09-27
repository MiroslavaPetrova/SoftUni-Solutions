namespace CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T> where T : IComparable<T>
    {
        private readonly List<T> myList;  // TODO rename the List & maybe the class name Box
                                                // create Interface IBox to hold all props
        public Box()
        {
            this.myList = new List<T>();
        }

        public void Add(T element)
        {
            this.myList.Add(element);
        }

        public T Remove(int index)   
        {
            T removed = this.myList[index];
            this.myList.RemoveAt(index);

            return removed;            
        }

        public bool Contains(T element)
        {
            return this.myList.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.myList[index1];
            this.myList[index1] = this.myList[index2];
            this.myList[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var item in this.myList)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            T maxElement = this.myList.Max();
            return maxElement;
        }

        public T Min()
        {
            T minElement = this.myList.Min();
            return minElement;
        }

        public void Print()
        {
            foreach (var item in this.myList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
