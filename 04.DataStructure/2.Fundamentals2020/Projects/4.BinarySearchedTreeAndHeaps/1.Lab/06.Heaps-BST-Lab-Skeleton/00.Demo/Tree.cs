namespace _00.Demo
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        private readonly ICollection<Tree<T>> children;

        public Tree(T value, params Tree<T>[] children)
        {
            this.children = new List<Tree<T>>();

            this.Value = value;

            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => (IReadOnlyCollection<Tree<T>>)this.children;

        public Tree<T> Root => this;

        public ICollection<T> OrderBfs()
        {
            var collection = new List<T>();
            var trees = new Queue<Tree<T>>();
            trees.Enqueue(this.Root);

            while (trees.Any())
            {
                var currTree = trees.Dequeue();

                collection.Add(currTree.Value);

                foreach (var child in currTree.Children)
                {
                    trees.Enqueue(child);
                }
            }
            
            return collection;
        }

        public ICollection<T> OrderDfs()
        {
            var collection = new List<T>();
            OrderDfs(collection, this.Root);
            return collection;
        }

        private void OrderDfs(List<T> collection, Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                OrderDfs(collection, child);
            }

            collection.Add(tree.Value);
        }
    }
}
