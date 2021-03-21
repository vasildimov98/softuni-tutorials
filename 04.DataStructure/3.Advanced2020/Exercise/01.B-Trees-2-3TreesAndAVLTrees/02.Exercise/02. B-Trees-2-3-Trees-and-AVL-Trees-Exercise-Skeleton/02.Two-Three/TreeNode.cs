namespace _02.Two_Three
{
    using System;

    public class TreeNode<T> 
        where T : IComparable<T>
    {
        public TreeNode(T leftKey)
        {
            this.LeftKey = leftKey;
        }

        public T LeftKey;
        public T RightKey;

        public TreeNode<T> LeftChild;
        public TreeNode<T> MiddleChild;
        public TreeNode<T> RightChild;

        public bool IsThreeNode()
        {
            return this.RightKey != null;
        }

        public bool IsTwoNode()
        {
            return this.RightKey == null;
        }

        public bool IsLeaf()
        {
            return this.LeftChild == null && this.MiddleChild == null && this.RightChild == null;
        }
    }
}
