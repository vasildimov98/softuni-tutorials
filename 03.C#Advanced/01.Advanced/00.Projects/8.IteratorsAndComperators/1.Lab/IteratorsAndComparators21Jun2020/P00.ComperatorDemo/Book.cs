namespace P00.ComperatorDemo
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; }
        public int Year { get; }
        public IReadOnlyCollection<string> Authors { get; }

        public int CompareTo(Book other)
        {
            if (this.Title.CompareTo(other.Title) == 0)
            {
                return this.Year.CompareTo(other.Year);
            }

            return this.Title.CompareTo(other.Title);
        }
    }
}
