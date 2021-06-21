namespace P03.GenericCountMethod
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
        where T : IComparable
    {
        private ICollection<T> values;

        public Box()
        {
            this.values = new List<T>();
        }

        public void AddItem(T value)
            => this.values.Add(value);

        public int Counter(T comparer)
        {
            var count = 0;

            foreach (var value in this.values)
            {
                if (value.CompareTo(comparer) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
