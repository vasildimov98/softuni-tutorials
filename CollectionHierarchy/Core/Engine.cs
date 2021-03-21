namespace CollectionHierarchy.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using CollectionHierarchy.IO.Contracts;
    using CollectionHierarchy.Modules;

    public class Engine : IEngine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList list;

        private IReadable reader;
        private IWritable writer;
        private Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.list = new MyList();
        }
        public Engine(IReadable readerable, IWritable writable)
            : this()
        {
            this.reader = readerable;
            this.writer = writable;
        }
        public void Run()
        {
            AddElements();
            RemoveElements();
        }

        private void RemoveElements()
        {
            var number = int.Parse(this.reader.ReadLine());

            var listForAddRemoveCollection = new List<string>();
            var listForMyList = new List<string>();
            for (int i = 0; i < number; i++)
            {
                listForAddRemoveCollection.Add(this.addRemoveCollection.Remove());
                listForMyList.Add(this.list.Remove());
            }

            this.writer.WriteLine(string.Join(" ", listForAddRemoveCollection));
            this.writer.WriteLine(string.Join(" ", listForMyList));
        }

        private void AddElements()
        {
            var words = this.reader
                            .ReadLine()
                            .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            var listForAddCollection = new List<int>();
            var listForAddRemoveCollection = new List<int>();
            var listForMyList = new List<int>();
            foreach (var word in words)
            {
                listForAddCollection.Add(this.addCollection.Add(word));
                listForAddRemoveCollection.Add(this.addRemoveCollection.Add(word));
                listForMyList.Add(this.list.Add(word));
            }

            this.writer.WriteLine(string.Join(" ", listForAddCollection));
            this.writer.WriteLine(string.Join(" ", listForAddRemoveCollection));
            this.writer.WriteLine(string.Join(" ", listForMyList));
        }
    }
}
