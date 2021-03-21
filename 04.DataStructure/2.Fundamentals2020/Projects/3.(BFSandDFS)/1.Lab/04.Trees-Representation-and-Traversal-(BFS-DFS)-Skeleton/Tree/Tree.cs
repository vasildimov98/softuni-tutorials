namespace Tree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.Collections.ObjectModel;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var orderedBfsEl = new List<T>();

            if (IsRootDeleted)
            {
                return orderedBfsEl;
            }

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var currentSubTree = queue.Dequeue();
                orderedBfsEl.Add(currentSubTree.Value);

                foreach (var child in currentSubTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return orderedBfsEl;
        }

        public ICollection<T> OrderDfs()
        {
            if (IsRootDeleted)
            {
                return new Collection<T>();
            }

            return OrderDfsByStack();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindDfs(parentKey, this);
            this.CheckIfNodeIsEmpty(searchedNode);
            searchedNode.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);
            this.CheckIfNodeIsEmpty(searchedNode);

            foreach (var child in searchedNode.children)
            {
                child.Parent = null;
            }

            searchedNode.children.Clear();

            var parentNode = searchedNode.Parent;

            if (parentNode == null)
            {
                IsRootDeleted = true;
            }
            else
            {
                searchedNode.Parent = null;
                parentNode.children.Remove(searchedNode);
            }

            searchedNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            this.CheckIfNodeIsEmpty(firstNode);
            this.CheckIfNodeIsEmpty(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                this.SwapRoot(secondNode);
                return;
            }

            if (secondNode == null)
            {
                this.SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            var indexOfFirstNode = firstParent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstNode] = secondNode;
            secondParent.children[indexOfSecondNode] = firstNode;
        }

        private void SwapRoot(Tree<T> tree)
        {
            this.Value = tree.Value;
            this.children.Clear();
            foreach (var child in tree.Children)
            {
                this.children.Add(child);
            }
        }

        private Tree<T> FindDfs(T value, Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                var subtree = this.FindDfs(value, child);

                if (subtree != null && subtree.Value.Equals(value))
                {
                    return subtree;
                }
            }

            if (tree.Value.Equals(value))
            {
                return tree;
            }

            return null;
        }

        private Tree<T> FindBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentSubtree = queue.Dequeue();

                if (currentSubtree.Value.Equals(parentKey))
                {
                    return currentSubtree;
                }

                foreach (var child in currentSubtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void Dfs(List<T> list, Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                Dfs(list, child);
            }

            list.Add(tree.Value);
        }

        private ICollection<T> OrderDfsByStack()
        {
            var result = new Stack<T>();

            var stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Any())
            {
                var subtree = stack.Pop();
                result.Push(subtree.Value);

                foreach (var child in subtree.Children)
                {
                    stack.Push(child);
                }
            }

            return result.ToArray();
        }

        private void CheckIfNodeIsEmpty(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("There is no such node in the tree!");
            }
        }
    }
}
