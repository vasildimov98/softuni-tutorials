namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        private Dictionary<int, KeyValuePair<T, int>> nodeByDist;

        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;

            this.nodeByDist = new Dictionary<int, KeyValuePair<T, int>>();
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            this.FindTopView(this, 0, 1);

            return this.nodeByDist
                .Values
                .Select(k => k.Key)
                .ToList();
        }

        private void FindTopView(BinaryTree<T> current, int dist, int level)
        {
            if (current == null)
            {
                return;
            }

            if (!this.nodeByDist.ContainsKey(dist))
            {
                this.nodeByDist[dist] = new KeyValuePair<T, int>(current.Value, level); 
            }
            else if (this.nodeByDist[dist].Value > level)
            {
                this.nodeByDist[dist] = new KeyValuePair<T, int>(current.Value, level);
            }

            this.FindTopView(current.LeftChild, dist - 1, level + 1);
            this.FindTopView(current.RightChild, dist + 1, level + 1);
        }
    }
}
