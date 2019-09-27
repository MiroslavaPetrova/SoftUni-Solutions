namespace CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T> where T : IComparable
    {

        public Box(List<T> myList)
        {
            this.MyList = myList;
        }

        public List<T> MyList { get; set; }

        public void Add(T element)
        {
            this.MyList.Add(element);
        }

        public T Remove(int index)
        {
            T removed = this.MyList[index];
            this.MyList.RemoveAt(index);

            return removed;
        }

        public bool Contains(T element)
        {
            return this.MyList.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.MyList[index1];
            this.MyList[index1] = this.MyList[index2];
            this.MyList[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var item in this.MyList)
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
            T maxElement = this.MyList.Max();
            return maxElement;
        }

        public T Min()
        {
            T minElement = this.MyList.Min();
            return minElement;
        }

        public void Print()
        {
            foreach (var item in this.MyList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Sort(List<T> customList)
        {
            customList.Sort();
        }
    }
}
