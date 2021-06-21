using System.Collections;
using System.Collections.Generic;

namespace IteratorsDemo
{
    internal class BookEnumerator : IEnumerator<string>
    {
        private List<string> books;
        private int currentIndex = -1;

        public BookEnumerator(List<string> books)
        {
            this.books = books;
        }

        public string Current
            => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;
        public void Dispose() { }
       
        public bool MoveNext()
        {
            this.currentIndex++;

            if (this.currentIndex >= this.books.Count)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}