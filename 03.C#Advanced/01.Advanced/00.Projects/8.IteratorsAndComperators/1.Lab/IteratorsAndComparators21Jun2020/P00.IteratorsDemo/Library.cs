namespace IteratorsDemo
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Library : IEnumerable<string>
    {
        private List<string> books;

        public Library(params string[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return "Normal loop forward";
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }

            yield return "Reverse loop backwords";

            for (int i = this.books.Count - 1; i >= 0; i--)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
