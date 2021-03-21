namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() { }

        private BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public void Insert(T element)
        {
            var toInsert = new Node<T>(element, null, null);
            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                var currNode = this.Root;
                var prevNode = this.Root;
                while (currNode != null)
                {
                    prevNode = currNode;

                    if (this.IsLesser(element, currNode.Value))
                    {
                        currNode = currNode.LeftChild;
                    }
                    else if (this.IsGreater(element, currNode.Value))
                    {
                        currNode = currNode.RightChild;
                    }
                    else
                    {
                        return;
                    }
                }

                if (this.IsLesser(element, prevNode.Value))
                {
                    prevNode.LeftChild = toInsert;
                    if (this.LeftChild == null)
                    {
                        this.LeftChild = toInsert;
                    }
                }
                else
                {
                    prevNode.RightChild = toInsert;
                    if (this.RightChild == null)
                    {
                        this.RightChild = toInsert;
                    }
                }
            }
        }

        public bool Contains(T element)
        {
            var currNode = this.Root;
            while (currNode != null)
            {
                if (IsLesser(element, currNode.Value))
                {
                    currNode = currNode.LeftChild;
                }
                else if (IsGreater(element, currNode.Value))
                {
                    currNode = currNode.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currNode != null;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var currNode = this.Root;
            while (currNode != null 
                && !this.AreEqual(element, currNode.Value))
            {
                if (IsLesser(element, currNode.Value))
                {
                    currNode = currNode.LeftChild;
                }
                else if (IsGreater(element, currNode.Value))
                {
                    currNode = currNode.RightChild;
                }
            }

            return new BinarySearchTree<T>(currNode);
        }
        private bool AreEqual(T element, T parent)
        {
            return element.CompareTo(parent) == 0;
        }

        private bool IsGreater(T element, T parent)
        {
            return element.CompareTo(parent) > 0;
        }

        private bool IsLesser(T element, T parent)
        {
            return element.CompareTo(parent) < 0;
        }

        private void Copy(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value);
                this.Copy(node.LeftChild);
                this.Copy(node.RightChild);
            }
        }
    }
}
