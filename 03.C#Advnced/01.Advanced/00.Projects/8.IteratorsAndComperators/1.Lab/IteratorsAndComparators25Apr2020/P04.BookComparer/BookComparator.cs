using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book firstBook, [AllowNull] Book secondBook)
        {
            var comperator = firstBook.Title.CompareTo(secondBook.Title);

            if (comperator == 0)
            {
                return secondBook.Year.CompareTo(firstBook.Year);
            }

            return comperator;
        }
    }
}
