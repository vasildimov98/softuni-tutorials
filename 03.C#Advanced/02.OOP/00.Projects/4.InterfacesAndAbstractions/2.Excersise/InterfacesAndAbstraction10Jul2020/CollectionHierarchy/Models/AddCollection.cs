namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class AddCollection : IAddable
    {
        private int count;
        private readonly ICollection<string> list;

        public AddCollection()
        {
            this.list = new List<string>();
        }

        public int Add(string element)
        {
            this.list.Add(element);

            return count++;
        }
    }
}
