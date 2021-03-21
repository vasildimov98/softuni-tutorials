namespace Tree
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key)
        {
            this.Key = key;

            this.children = new List<Tree<T>>();
        }

        public Tree(T key, params Tree<T>[] children)
            : this(key)
        {
            foreach (var child in children)
            {
                this.AddChild(child);
                this.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var treeAsString = new StringBuilder();
            var whiteSpaceCount = 0;
            this.DfsOrder(treeAsString, this, whiteSpaceCount);
            return treeAsString.ToString().TrimEnd();
        }

        public List<T> GetLeafKeys()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            var leafNodes = new List<T>();

            while (queue.Any())
            {
                var currNode = queue.Dequeue();

                if (this.IsLeaf(currNode))
                {
                    leafNodes.Add(currNode.Key);
                }

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes.OrderBy(x => x).ToList();
        }

        public List<T> GetMiddleKeys()
        {
            bool predicate(Tree<T> tree)
                => this.IsMiddle(tree);

            var middleNodes = new List<T>();
            this.DfsOrder(middleNodes, this, predicate);
            return middleNodes.OrderBy(x => x).ToList();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            bool predicate(Tree<T> tree)
                => this.IsLeaf(tree);

            var leafs = new List<Tree<T>>(); 
            this.DfsOrder(leafs, this, predicate);

            var deepestLeftMostNode = this;
            var currDepth = 0;
            foreach (var leaf in leafs)
            {
                var currNodeDepth = this.GetNodeDepth(leaf);

                if (currDepth < currNodeDepth)
                {
                    currDepth = currNodeDepth;
                    deepestLeftMostNode = leaf;
                }
            }
            
            return deepestLeftMostNode;
        }

        public List<T> GetLongestPath()
        {
            var stack = new Stack<T>();
            var deepestNode = this.GetDeepestLeftomostNode();
            GetStackOfThePath(stack, deepestNode);

            return new List<T>(stack);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var paths = new List<List<T>>();
            var path = new List<T>
            {
                this.Key
            };

            var currSum = 0;

            this.GetPathSum(paths, path, this, sum, currSum);

            return paths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            bool predicate(Tree<T> tree, int wantedSum)
                => this.HasWantedSum(tree, wantedSum);

            return this.OrderBfs(predicate, sum);
        }

        private bool HasWantedSum(Tree<T> tree, int wantedSum)
        {
            var expectedSum = this.GetCurrentSubtreeSum(tree);

            return expectedSum == wantedSum;
        }

        private int GetCurrentSubtreeSum(Tree<T> node)
        {
            var currSum = Convert.ToInt32(node.Key);
            var pathSum = 0;
            foreach (var child in node.Children)
            {
                pathSum += this.GetCurrentSubtreeSum(child);
            }

            return currSum + pathSum;
        }

        private List<Tree<T>> OrderBfs(Func<Tree<T>, int, bool> predicate, int sum)
        {
            var treesWithSum = new List<Tree<T>>();
            var trees = new Queue<Tree<T>>();
            trees.Enqueue(this);

            while (trees.Any())
            {
                var currTree = trees.Dequeue();

                if (predicate(currTree, sum))
                {
                     treesWithSum.Add(currTree);
                }

                foreach (var child in currTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            return treesWithSum;
        }

        private void GetPathSum(List<List<T>> paths, List<T> path, Tree<T> tree, int sum, int currSum)
        {
            currSum += Convert.ToInt32(tree.Key);

            foreach (var child in tree.Children)
            {
                path.Add(child.Key);
                this.GetPathSum(paths, path, child, sum, currSum);
            }

            if (currSum == sum)
            {
                paths.Add(new List<T>(path));
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void GetStackOfThePath(Stack<T> longestPath, Tree<T> deepestNode)
        {
            while (deepestNode != null)
            {
                longestPath.Push(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }
        }

        private int GetNodeDepth(Tree<T> node)
        {
            var depth = 0;
            while (node.Parent != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }

        private bool IsMiddle(Tree<T> tree)
        {
            return tree.Parent != null && tree.Children.Any();
        }

        private bool IsLeaf(Tree<T> currNode)
        {
            return !currNode.children.Any();
        }

        private void DfsOrder(List<T> wantedNodes, Tree<T> tree, Predicate<Tree<T>> predicate)
        {
            foreach (var child in tree.Children)
            {
                this.DfsOrder(wantedNodes, child, predicate);
            }

            if (predicate(tree))
            {
                wantedNodes.Add(tree.Key);
            }
        }

        private void DfsOrder(List<Tree<T>> wantedNodes, Tree<T> tree, Predicate<Tree<T>> predicate)
        {
            foreach (var child in tree.Children)
            {
                this.DfsOrder(wantedNodes, child, predicate);
            }

            if (predicate(tree))
            {
                wantedNodes.Add(tree);
            }
        }

        private void DfsOrder(StringBuilder sb, Tree<T> tree, int whiteSpace)
        {
            sb.AppendLine($"{new string(' ', whiteSpace)}{tree.Key}");

            foreach (var child in tree.Children)
            {
                this.DfsOrder(sb, child, whiteSpace + 2);
            }
        }
    }
}
