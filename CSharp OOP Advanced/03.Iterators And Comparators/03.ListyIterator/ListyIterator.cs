namespace ListyIterator
{
    using System;

    public class ListyIterator<T>
    {
        private T[] elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index < this.elements.Length - 1)
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.elements.Length - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.elements.Length > 0)
            {
                Console.WriteLine($"{this.elements[this.index]}");
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
