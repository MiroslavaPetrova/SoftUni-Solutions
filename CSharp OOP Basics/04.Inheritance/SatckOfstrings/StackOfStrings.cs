using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings : List<string>
    {
        public void Push(string item)
        {
           Add(item);
        }

        public string Peek()
        {
            return GetLastElement();
        }

        public string Pop()
        {
            string element = GetLastElement();
            RemoveAt(Count - 1);

            return element;
        }

        public bool IsEmpty()
        {
            return Count < 1;
        }

        private string GetLastElement()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return this.Last();
        }
    }
}
