namespace CollectionHierarchy.Modules
{
    using CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    public class AddRemoveCollection : IAddable, IRemovable
    {
        private IList<string> list;

        public AddRemoveCollection()
        {
            this.list = new List<string>();
        }

        public IReadOnlyCollection<string> List =>
            (IReadOnlyCollection<string>)this.list;
        public int Add(string word)
        {
            this.list.Insert(0, word);

            return 0;
        }

        public string Remove()
        {
            var removed = this.list[this.List.Count - 1];
            this.list.RemoveAt(this.List.Count - 1);
            return removed;
        }
    }
}
