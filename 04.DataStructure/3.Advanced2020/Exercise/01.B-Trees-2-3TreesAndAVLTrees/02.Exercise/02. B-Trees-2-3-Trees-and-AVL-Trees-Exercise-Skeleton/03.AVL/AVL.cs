namespace _03.AVL
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public AVL() { }

        public void Insert(T value)
        {
            this.Root = this.InsertNode(this.Root, value);
        }

        public void Delete(T value)
        {
            if (this.Contains(value))
            {
                this.Root = this.RemoveNode(this.Root, value);
            }
        }

        public void DeleteMin()
        {
            this.Root = this.RemoveSmallestNode(this.Root);
        }

        public void EachInOrder(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            this.EachInOrder(this.Root, action);
        }

        public bool Contains(T value)
        {
            return this.SearchValue(this.Root, value) != null;
        }

        private Node<T> RemoveNode(Node<T> node, T value)
        {
            if (this.IsEqual(value, node.Value))
                if (this.IsLeaf(node))
                    return null;
                else if (this.HasOnlyRightSubtree(node))
                    return node.Right;
                else if (this.HasOnlyLeftSubtree(node))
                    return node.Left;
                else
                {
                    if (this.IsRightSideHeavy(node))
                    {
                        var smallestNodeOfRightSubtree = this.GetSmallestNode(node.Right);
                        node.Right = this.RemoveNode(node.Right, smallestNodeOfRightSubtree.Value);

                        node = new Node<T>(smallestNodeOfRightSubtree.Value)
                        {
                            Left = node.Left,
                            Right = node.Right,
                        };
                    }
                    else
                    {
                        var greatestNodeOfLeftSubtree = this.GetGreatestNode(node.Left);
                        node.Left = this.RemoveNode(node.Left, greatestNodeOfLeftSubtree.Value);

                        node = new Node<T>(greatestNodeOfLeftSubtree.Value)
                        {
                            Left = node.Left,
                            Right = node.Right,
                        };
                    }

                    node = this.Balance(node);
                    this.UpdateHeight(node);
                    return node;
                }

            if (this.IsLess(value, node.Value))
                node.Left = this.RemoveNode(node.Left, value);
            if (this.IsGreater(value, node.Value))
                node.Right = this.RemoveNode(node.Right, value);


            node = this.Balance(node);
            this.UpdateHeight(node);
            return node;
        }

        private bool IsRightSideHeavy(Node<T> node)
        {
            return node.Right.Height >= node.Left.Height;
        }

        private bool HasOnlyLeftSubtree(Node<T> node)
        {
            return node.Left != null
                && node.Right == null;
        }

        private bool HasOnlyRightSubtree(Node<T> node)
        {
            return node.Right != null
                && node.Left == null;
        }

        private bool IsLeaf(Node<T> node)
        {
            return node.Left == null
                && node.Right == null;
        }

        private Node<T> RemoveSmallestNode(Node<T> node)
        {
            if (node == null)
                return null;

            if (node.Left == null)
                return node.Right;


            if (node.Left != null)
                node.Left = this.RemoveSmallestNode(node.Left);

            node = this.Balance(node);
            this.UpdateHeight(node);
            return node;
        }

        private Node<T> GetSmallestNode(Node<T> subtree)
        {
            if (subtree == null)
                return null;

            if (subtree.Left != null)
                return this.GetSmallestNode(subtree.Left);
            return subtree;
        }

        private Node<T> GetGreatestNode(Node<T> subtree)
        {
            if (subtree == null)
                return null;

            if (subtree.Right != null)
                return this.GetGreatestNode(subtree.Right);

            return subtree;
        }

        private Node<T> SearchValue(Node<T> node, T value)
        {
            if (node == null)
                return null;

            var valueIsLess = this.IsLess(value, node.Value);
            var valueIsGreater = this.IsGreater(value, node.Value);
            if (valueIsLess)
            {
                return this.SearchValue(node.Left, value);
            }
            else if (valueIsGreater)
            {
                return this.SearchValue(node.Right, value);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action.Invoke(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node<T> InsertNode(Node<T> node, T value)
        {
            // found the place where to insert the node!!!
            if (node == null)
            {
                return new Node<T>(value);
            }

            bool valueIsLess = this.IsLess(value, node.Value);
            bool valueIsGreater = this.IsGreater(value, node.Value);
            if (valueIsLess)
            {
                node.Left = this.InsertNode(node.Left, value);
            }
            else if (valueIsGreater)
            {
                node.Right = this.InsertNode(node.Right, value);
            }

            node = this.Balance(node);
            this.UpdateHeight(node);
            return node;
        }

        private Node<T> Balance(Node<T> node)
        {
            var parentBalanceFactor = this.Height(node.Right) - this.Height(node.Left);

            if (parentBalanceFactor > 1) // tree is right heavy => this needs left rotation;
            {
                var rightChildBalanceFactor = this.Height(node.Right.Right)
                    - this.Height(node.Right.Left);

                if (rightChildBalanceFactor < 0)
                // right child is left heavy so it needs first right rotation than left rotation to his parent;
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }
            else if (parentBalanceFactor < -1) // tree is left heavy => this needs right rotation
            {
                var leftChildBalanceFactor = this.Height(node.Left.Right) - this.Height(node.Left.Left);

                if (leftChildBalanceFactor > 0)
                // left child is right heavy => this needs first left rotation to the child and next right rotation to his parent;
                {
                    node.Left = this.RotateLeft(node.Left);
                }

                node = this.RotateRight(node);
            }

            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var rightChild = node.Right;
            node.Right = rightChild.Left;
            rightChild.Left = node;

            this.UpdateHeight(node);

            return rightChild;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var leftChild = node.Left;
            node.Left = leftChild.Right;
            leftChild.Right = node;

            this.UpdateHeight(node);

            return leftChild;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(this.Height(node.Right), this.Height(node.Left)) + 1;
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private bool IsLess(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) < 0;
        }

        private bool IsGreater(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) > 0;
        }

        private bool IsEqual(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) == 0;
        }
    }
}
