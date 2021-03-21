namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddRemoveCollection : IAddable, IRemovable
    {
        private const int START_INDEX = 0;

        private readonly List<string> list;
        private int count;

        public AddRemoveCollection()
        {
            this.list = new List<string>();
        }

        public int Add(string element)
        {
            this.list.Insert(START_INDEX, element);

            count++;

            return START_INDEX;
        }

        public string Remove()
        {
            var element = this.list[count - 1];

            this.list.RemoveAt(count - 1);

            this.count--;

            return element;
        }
    }
}
