namespace P01.ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> list;
        private int index = 0;

        public ListyIterator(IList<T> list)
        {
            this.list = list;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
            => this.index + 1 < this.list.Count;
        public void Print()
        {
            if (this.list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }

            Console.WriteLine(this.list[index]);
        }

        public void PrintAll()
        {
            try
            {
                Console.WriteLine(string.Join(" ", this.list));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
