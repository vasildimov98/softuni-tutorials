namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T value, Node<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value { get; }

        public Node<T> Next { get; set; }
    }
}