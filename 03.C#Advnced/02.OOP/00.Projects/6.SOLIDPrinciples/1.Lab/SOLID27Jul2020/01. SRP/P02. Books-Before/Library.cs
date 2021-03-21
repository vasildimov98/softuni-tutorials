namespace P02._Books_Before
{
    using System.Linq;
    using System.Collections.Generic;

    public class Library
    {
        private readonly ICollection<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        public Book FindBook(string title)
            => this.books
            .FirstOrDefault(b => b.Title == title);
    }
}
