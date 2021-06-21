using System;
using System.Collections;
using System.Collections.Generic;

namespace P02.Collection
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private const int InitialIndexValue = 0;

        private List<T> elements;
        private int currentIndex;

        public ListyIterator()
        {
            this.elements = new List<T>();
            this.currentIndex = InitialIndexValue;
        }

        public ListyIterator(List<T> parameters)
            : this()
        {
            this.elements = parameters;
        }

        public bool Move()
        {
            if (this.currentIndex < this.elements.Count - 1)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex + 1 < this.elements.Count;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(this.elements[this.currentIndex]);
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            try
            {
                Console.WriteLine(string.Join(" ", this.elements));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
