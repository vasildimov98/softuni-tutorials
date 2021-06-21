using System.Collections.Generic;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private const int IntialIndexValue = 0;

        private readonly List<T> elements;
        private int currentIndex;

        public ListyIterator()
        {
            this.elements = new List<T>();
            this.currentIndex = IntialIndexValue; 
        }
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
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
            return this.currentIndex < this.elements.Count - 1;
        }

        public void Print()
        {
            if (this.currentIndex >= this.elements.Count)
            {
                System.Console.WriteLine("Invalid Operation!");
            }
            else
            {
                System.Console.WriteLine(this.elements[currentIndex]);
            }
        }
    }
}
