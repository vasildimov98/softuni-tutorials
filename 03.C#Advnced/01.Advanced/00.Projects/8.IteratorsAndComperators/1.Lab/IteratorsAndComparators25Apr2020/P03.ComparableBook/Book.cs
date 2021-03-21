using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] author)
        {
            this.Title = title;
            this.Year = year;
            this.Author = author;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Author { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            var comperator = this.Year.CompareTo(other.Year);

            if (comperator == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return comperator;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
