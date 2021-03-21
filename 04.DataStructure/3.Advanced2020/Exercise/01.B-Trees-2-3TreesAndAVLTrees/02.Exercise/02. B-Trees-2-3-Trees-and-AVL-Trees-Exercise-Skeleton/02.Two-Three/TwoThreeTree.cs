namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            // It is self-balancing therefore the root sometimes changes;
            // We call another method which will create and insert the new node in the correct place and return the root;
            this.root = this.GetRoot(this.root, key);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private TreeNode<T> GetRoot(TreeNode<T> node, T key)
        {
            // only the first time;
            if (node == null)
            {
                return new TreeNode<T>(key);
            }

            return this.FindLeafNode(node, key);
        }

        private TreeNode<T> FindLeafNode(TreeNode<T> current, T key)
        {
            if (current.IsLeaf())
            {
                return MergeNodes(current, new TreeNode<T>(key));
            }

            if (this.IsLess(key, current.LeftKey))
            {
                var foundNode = this.FindLeafNode(current.LeftChild, key);

                if (foundNode == current.LeftChild)
                {
                    return current;
                }
                else
                {
                    return MergeNodes(current, foundNode);
                }
            }
            else if (current.IsTwoNode()
                || this.IsLess(key, current.RightKey))
            {
                var foundNode = this.FindLeafNode(current.MiddleChild, key);

                if (foundNode == current.MiddleChild)
                {
                    return current;
                }
                else
                {
                    return MergeNodes(current, foundNode);
                }
            }
            else
            {
                var foundNode = this.FindLeafNode(current.RightChild, key);

                if (foundNode == current.RightChild)
                {
                    return current;
                }
                else
                {
                    return MergeNodes(current, foundNode);
                }
            }
        }

        private TreeNode<T> MergeNodes(TreeNode<T> leafNode, TreeNode<T> newNode)
        {
            if (leafNode.IsTwoNode())
            {
                if (this.IsLess(leafNode.LeftKey, newNode.LeftKey))
                {
                    leafNode.RightKey = newNode.LeftKey;
                    leafNode.MiddleChild = newNode.LeftChild;
                    leafNode.RightChild = newNode.MiddleChild;
                }
                else
                {
                    leafNode.RightKey = leafNode.LeftKey;
                    leafNode.LeftKey = newNode.LeftKey;
                    leafNode.RightChild = leafNode.MiddleChild;
                    leafNode.MiddleChild = newNode.MiddleChild;
                }

                return leafNode;
            }
            else if (this.IsGreater(leafNode.LeftKey, newNode.LeftKey)
                || this.IsEqual(leafNode.LeftKey, newNode.LeftKey))
            {
                var mergeNode = new TreeNode<T>(leafNode.LeftKey)
                {
                    LeftChild = newNode,
                    MiddleChild = leafNode,
                };

                leafNode.LeftKey = leafNode.RightKey;
                leafNode.RightKey = default;

                leafNode.LeftChild = leafNode.MiddleChild;
                leafNode.MiddleChild = leafNode.RightChild;
                leafNode.RightChild = null;
                return mergeNode;
            }
            else if (this.IsGreater(leafNode.RightKey, newNode.LeftKey)
                || this.IsEqual(leafNode.RightKey, newNode.LeftKey))
            {
                newNode.MiddleChild = new TreeNode<T>(leafNode.RightKey)
                {
                    LeftChild = newNode.MiddleChild,
                    MiddleChild = leafNode.RightChild,
                };
                leafNode.RightKey = default;

                leafNode.MiddleChild = newNode.LeftChild;
                newNode.LeftChild = leafNode;
                leafNode.RightChild = null;
                return newNode;
            }
            else
            {
                var mergeNode = new TreeNode<T>(leafNode.RightKey)
                {
                    LeftChild = leafNode,
                    MiddleChild = newNode
                };

                leafNode.RightKey = default;
                leafNode.RightChild = null;
                return mergeNode;
            }
        }

        private bool IsLess(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }
        private bool IsGreater(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) > 0;
        }

        private bool IsEqual(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) == 0;
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
