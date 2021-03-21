namespace _01.BinaryTree
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild = null
            , IAbstractBinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();
            this.GetPreOrderTreeInString(sb, indent, this);
            return sb.ToString().TrimEnd();
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var preOrderTrees = new List<IAbstractBinaryTree<T>>();
            this.PreOrder(preOrderTrees, this);
            return preOrderTrees;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var inOrderTrees = new List<IAbstractBinaryTree<T>>();
            this.InOrder(inOrderTrees, this);
            return inOrderTrees;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var postOrderTrees = new List<IAbstractBinaryTree<T>>();
            this.PostOrder(postOrderTrees, this);
            return postOrderTrees;
        }

        public void ForEachInOrder(Action<T> action)
        {
            this.ForEachInOrder(action, this);
        }

        private void ForEachInOrder(Action<T> action, IAbstractBinaryTree<T> tree)
        {
            if (tree != null)
            {
                this.ForEachInOrder(action, tree.LeftChild);
                action.Invoke(tree.Value);
                this.ForEachInOrder(action, tree.RightChild);
            }
        }

        private void PostOrder(List<IAbstractBinaryTree<T>> trees, IAbstractBinaryTree<T> tree)
        {
            if (tree != null)
            {
                this.PostOrder(trees, tree.LeftChild);
                this.PostOrder(trees, tree.RightChild);
                trees.Add(tree);
            }
        }

        private void InOrder(List<IAbstractBinaryTree<T>> trees, IAbstractBinaryTree<T> tree)
        {
            if (tree != null)
            {
                this.InOrder(trees, tree.LeftChild);
                trees.Add(tree);
                this.InOrder(trees, tree.RightChild);
            }
        }

        private void PreOrder(List<IAbstractBinaryTree<T>> trees, IAbstractBinaryTree<T> tree)
        {
            if (tree != null)
            {
                trees.Add(tree);
                this.PreOrder(trees, tree.LeftChild);
                this.PreOrder(trees, tree.RightChild);
            }
        }

        private void GetPreOrderTreeInString(StringBuilder sb, int indent, IAbstractBinaryTree<T> tree)
        {
            if (tree != null)
            {
                sb.AppendLine($"{new string(' ', indent)}{tree.Value}");
                this.GetPreOrderTreeInString(sb, indent + 2, tree.LeftChild);
                this.GetPreOrderTreeInString(sb, indent + 2, tree.RightChild);
            }
        }
    }
}
