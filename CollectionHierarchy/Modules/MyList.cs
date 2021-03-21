namespace CollectionHierarchy.Modules
{
    using CollectionHierarchy.Contracts;
    using System.Collections;
    using System.Collections.Generic;

    class MyList : IAddable, IRemovable, IUsable
    {
        private IList<string> list;

        public MyList()
        {
            this.list = new List<string>();
        }

        public IReadOnlyCollection<string> List =>
            (IReadOnlyCollection<string>)this.list;
        public int Used => this.List.Count;

        public int Add(string word)
        {
            this.list.Insert(0, word);

            return 0;
        }

        public string Remove()
        {
            var removed = this.list[0];
            this.list.RemoveAt(0);
            return removed;
        }
    }
}
