using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public int CounterForGreaterElement(T element)
        {
            var count = 0;

            for (int i = 0; i < this.Values.Count; i++)
            {
                var comparable = element.CompareTo(this.Values[i]);

                if (comparable < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
