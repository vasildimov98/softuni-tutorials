namespace P03.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private readonly int[] stones;

        public Lake(params int[] stones)
        {
            this.stones = stones;
        }

        public int Count => stones.Length;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Count; i += 2)
            {
                yield return stones[i];
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
