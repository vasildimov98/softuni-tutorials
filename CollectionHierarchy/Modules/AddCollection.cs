namespace CollectionHierarchy.Modules
{
    using CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    class AddCollection : IAddable
    {
        private ICollection<string> list;

        public AddCollection()
        {
            this.list = new List<string>();
        }

        public IReadOnlyCollection<string> List =>
            (IReadOnlyCollection<string>)this.list;
        public int Add(string word)
        {
            this.list.Add(word);

            return this.List.Count - 1;
        }
    }
}
