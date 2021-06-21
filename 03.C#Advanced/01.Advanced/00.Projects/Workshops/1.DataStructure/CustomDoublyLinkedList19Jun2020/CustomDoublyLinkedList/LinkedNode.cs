namespace CustomDoublyLinkedList
{
    /// <summary>
    /// A generic Node, which holdes value, NextNode, PrevNode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedNode<T>
    {
        /// <summary>
        /// Instantiate new Node with current value;
        /// </summary>
        /// <param name="value"></param>
        public LinkedNode(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// The value of the current Node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The reference to the next node in the memory
        /// </summary>
        public LinkedNode<T> NextNode { get; set; }
        /// <summary>
        /// The reference to the previous node in the memory
        /// </summary>
        public LinkedNode<T> PreviousNode { get; set; }

        /// <summary>
        /// Overrides the object method toString();
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
