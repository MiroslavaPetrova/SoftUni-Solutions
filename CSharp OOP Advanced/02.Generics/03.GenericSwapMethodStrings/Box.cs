using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        private List<T> items;

        public Box(List<T> items)
        {
            this.items = items;
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.items[index1];
            this.items[index1] = this.items[index2];
            this.items[index2] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
