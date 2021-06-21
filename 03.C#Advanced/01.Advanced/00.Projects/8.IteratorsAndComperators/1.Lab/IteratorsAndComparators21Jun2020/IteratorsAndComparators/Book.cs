namespace IteratorsAndComparators
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
        public int CompareTo([AllowNull] Book other)
        {
            if (this.Year > other.Year)
            {
                return 1;
            }
            else if (this.Year < other.Year)
            {
                return -1;
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }
    }
}
