namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() { }

        public BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => this.Root == null ? 0 : this.Root.Count;

        public void Insert(T element)
        {
            var newNode = new Node<T>(element, null, null);
            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                this.InsertRecursively(this.Root, newNode, null);
            }
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.Root == null)
            {
                return;
            }

            var stackWithTrees = new Stack<Node<T>>();
            var curr = this.Root;

            while (curr != null || stackWithTrees.Count > 0)
            {
                while (curr != null)
                {
                    stackWithTrees.Push(curr);
                    curr = curr.LeftChild;
                }

                curr = stackWithTrees.Pop();

                action.Invoke(curr.Value);
                curr = curr.RightChild;
            }
        }

        public bool Contains(T element)
        {
            var curr = this.Root;
            while (curr != null)
            {
                if (this.IsLess(element, curr.Value))
                {
                    curr = curr.LeftChild;
                }
                else if (this.IsGreater(element, curr.Value))
                {
                    curr = curr.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var curr = this.Root;

            while (curr != null)
            {
                if (this.IsLess(element, curr.Value))
                {
                    curr = curr.LeftChild;
                }
                else if (this.IsGreater(element, curr.Value))
                {
                    curr = curr.RightChild;
                }
                else
                {
                    break;
                }
            }

            return new BinarySearchTree<T>(curr);
        }

        public List<T> Range(T lower, T upper)
        {
            var collection = new List<T>();
            this.FillCollection(collection, this.Root, lower, upper);
            return collection;
        }

        public void DeleteMin()
        {
            this.ValidateIfCollectionIsEmpty();

            if (this.Root.LeftChild == null)
            {
                this.LeftChild = null;
                this.Root = this.RightChild;
            }
            else
            {
                var curr = this.Root;
                var prev = this.Root;
                while (curr.LeftChild != null)
                {
                    prev = curr;
                    prev.Count--;
                    curr = curr.LeftChild;
                }

                prev.LeftChild = curr.RightChild;
            }
        }

        public void DeleteMax()
        {
            this.ValidateIfCollectionIsEmpty();

            if (this.Root.RightChild == null)
            {
                this.RightChild = null;
                this.Root = this.LeftChild;
            }
            else
            {
                var curr = this.Root;
                var prev = this.Root;
                while (curr.RightChild != null)
                {
                    prev = curr;
                    prev.Count--;
                    curr = curr.RightChild;
                }

                prev.RightChild = curr.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return this.GetRankRecursively(this.Root, element);
        }

        private int GetRankRecursively(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(element, current.Value))
            {
                return this.GetRankRecursively(current.LeftChild, element);
            }
            else if (this.IsEqual(element, current.Value))
            {
                return this.GetRankRecursively(current.LeftChild, element) + 1;
            }

            return 1 + this.GetCount(current.LeftChild) + this.GetRankRecursively(current.RightChild, element);
        }

        private int GetCount(Node<T> leftChild)
        {
            return leftChild == null ? 0 : leftChild.Count; 
        }

        private void FillCollection(List<T> collection, Node<T> current, T lower, T upper)
        {
            if (current == null)
            {
                return;
            }

            this.FillCollection(collection, current.LeftChild, lower, upper);

            if (this.IsLess(lower, current.Value) && this.IsGreater(upper, current.Value))
            {
                collection.Add(current.Value);
            }
            else if (this.IsEqual(lower, current.Value) || this.IsEqual(upper, current.Value))
            {
                collection.Add(current.Value);
            }

            this.FillCollection(collection, current.RightChild, lower, upper);
        }

        private void InOrderRecursively(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                this.InOrderRecursively(current.LeftChild, action);
                action.Invoke(current.Value);
                this.InOrderRecursively(current.RightChild, action);
            }
        }

        private void InsertRecursively(Node<T> current, Node<T> newNode, Node<T> prev)
        {
            if (current == null)
            {
                if (this.IsLess(newNode.Value, prev.Value))
                {
                    prev.LeftChild = newNode;
                    if (this.LeftChild == null)
                    {
                        this.LeftChild = newNode;
                    }
                }
                else
                {
                    prev.RightChild = newNode;
                    if (this.RightChild == null)
                    {
                        this.RightChild = newNode;
                    }
                }

                return;
            }

            prev = current;
            if (this.IsLess(newNode.Value, current.Value))
            {
                this.InsertRecursively(current.LeftChild, newNode, prev);
                prev.Count++;
            }
            else if (this.IsGreater(newNode.Value, current.Value))
            {
                this.InsertRecursively(current.RightChild, newNode, prev);
                prev.Count++;
            }
            else
            {
                return;
            }
        }

        private bool IsEqual(T border, T value)
        {
            return border.CompareTo(value) == 0;
        }

        private bool IsGreater(T newValue, T prevValue)
        {
            return newValue.CompareTo(prevValue) > 0;
        }

        private bool IsLess(T newValue, T prevValue)
        {
            return newValue.CompareTo(prevValue) < 0;
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }

        private void ValidateIfCollectionIsEmpty()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("BST is empty!");
            }
        }
    }
}
