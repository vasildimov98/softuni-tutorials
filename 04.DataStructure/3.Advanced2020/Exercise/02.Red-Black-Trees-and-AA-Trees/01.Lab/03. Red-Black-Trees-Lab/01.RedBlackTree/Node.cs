namespace _01.RedBlackTree
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Color = true;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public int Count { get; set; }

        public bool Color { get; set; }
    }
}
