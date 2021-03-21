namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class MyList : IAddable, IRemovable
    {
        private const int START_INDEX = 0;

        private readonly List<string> list;

        public MyList()
        {
            this.list = new List<string>();
        }

        public int Used => this.list.Count;

        public int Add(string element)
        {
            list.Insert(START_INDEX, element);

            return START_INDEX; 
        }

        public string Remove()
        {
            var element = this.list[START_INDEX];

            this.list.RemoveAt(START_INDEX);

            return element;
        }
    }
}
