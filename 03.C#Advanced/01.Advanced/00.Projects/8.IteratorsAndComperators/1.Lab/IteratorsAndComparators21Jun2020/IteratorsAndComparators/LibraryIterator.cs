namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex = -1;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current
            => this.books[this.currentIndex];

        object IEnumerator.Current
            => this.Current;

        public void Dispose() { }

        public bool MoveNext()
            => ++this.currentIndex < this.books.Count;

        public void Reset() =>
            this.currentIndex = -1;
    }
}
