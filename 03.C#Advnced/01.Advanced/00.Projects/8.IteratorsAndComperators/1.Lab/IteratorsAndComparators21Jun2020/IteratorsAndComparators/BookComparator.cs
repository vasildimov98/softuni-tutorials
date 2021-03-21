namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book firstBook, [AllowNull] Book secondBook)
        {
            var result = firstBook.Title.CompareTo(secondBook.Title);

            if (result == 0)
            {
                result = secondBook.Year.CompareTo(firstBook.Year);
            }

            return result;
        }
    }
}
