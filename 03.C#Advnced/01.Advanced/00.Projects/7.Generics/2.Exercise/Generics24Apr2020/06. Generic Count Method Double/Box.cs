using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.List = new List<T>();
        }
        public List<T> List { get; set; }

        public int CountOfElementsGreaterThanElement(T elemen)
        {
            var count = 0;

            for (int i = 0; i < this.List.Count; i++)
            {
                var comparable = elemen.CompareTo(this.List[i]);

                if (comparable < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
