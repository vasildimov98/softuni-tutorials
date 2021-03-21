using System.Text;

namespace _01.BSTOperations
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public int Count { get; set; }

        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            this.Value = value;

            this.Count++;

            if (leftChild != null)
            {
                this.Count++;
            }

            if (rightChild != null)
            {
                this.Count++;
            }

            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .Append(this.Value.ToString() + " ")
                .Append(this.LeftChild?.Value.ToString() + " ")
                .Append(this.RightChild?.Value.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
