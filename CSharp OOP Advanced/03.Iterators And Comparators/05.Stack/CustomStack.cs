namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        //private T[] elements;          //TODO try working with an Arr instead of List
        private List<T> elements;

        public CustomStack()
        {
            this.elements = new List<T>();
        }

        public void Push(T [] item)
        {
            this.elements.AddRange(item);
        }

        public void Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            else
            {
                this.elements.RemoveAt(this.elements.Count - 1);  // check Length

            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
