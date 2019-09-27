namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i+=2)
            {
                yield return this.stones[i];
            }

            int oddIndex = (this.stones.Length - 1) % 2 == 0 ? this.stones.Length - 2
                : this.stones.Length - 1; 
            //int lastIndex = this.stones.Length - 1;

            //if (lastIndex % 2 == 0)
            //{
            //    oddIndex = this.stones.Length - 2;
            //}
            //else
            //{
            //    oddIndex = this.stones.Length - 1;
            //}

            for (int i = oddIndex; i > 0; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
