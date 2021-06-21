namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of ListNodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : IEnumerable
        where T : IComparable
    {
        private const int EMPTY_COLLECTION = 0;

        /// <summary>
        /// The first node (element) in the collection
        /// </summary>
        private LinkedNode<T> head;

        /// <summary>
        /// The last node (element) in the collection
        /// </summary>
        private LinkedNode<T> tail;

        /// <summary>
        /// Empty constructor 
        /// </summary>
        public DoublyLinkedList() { }

        /// <summary>
        /// Initializes a new instance of the LinkedList<T> class that contains elements copied from the specified IEnumerable and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"></param>
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "The collection cannot be null!");
            }

            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        /// <summary>
        /// Return the count of elements in the collection
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///  Adds the specified new node after the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddAfter(LinkedNode<T> node, LinkedNode<T> newNode)
        {
            if (newNode == null || node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("Node doesn't exists!");
            }


            if (this.tail == currentNode)
            {
                this.AddLast(newNode.Value);
            }
            else
            {
                newNode.NextNode = currentNode.NextNode;
                newNode.PreviousNode = currentNode;
                currentNode.NextNode = newNode;
                currentNode.NextNode.PreviousNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        ///  Adds a new node containing the specified value
        ///  after the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddAfter(LinkedNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("Node doesn't exists!");
            }

            var newNode = new LinkedNode<T>(value);
            if (this.tail == currentNode)
            {
                this.AddLast(newNode.Value);
            }
            else
            {
                newNode.NextNode = currentNode.NextNode;
                newNode.PreviousNode = currentNode;
                currentNode.NextNode = newNode;
                currentNode.NextNode.PreviousNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds the specified new node before the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="newNode"></param>
        /// <param name="node"></param>
        public void AddBefore(LinkedNode<T> node, LinkedNode<T> newNode)
        {
            if (newNode == null || node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("Node doesn't exists!");
            }

            if (this.head == currentNode)
            {
                this.AddFirst(newNode.Value);
            }
            else
            {
                newNode.PreviousNode = currentNode.PreviousNode;
                newNode.NextNode = currentNode;
                currentNode.PreviousNode.NextNode = newNode;
                currentNode.PreviousNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        ///  Adds a new node containing the specified value
        ///  before the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddBefore(LinkedNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("Node doesn't exists!");
            }

            var newNode = new LinkedNode<T>(value);
            if (this.head == currentNode)
            {
                this.AddFirst(value);
            }
            else
            {
                newNode.PreviousNode = currentNode.PreviousNode;
                newNode.NextNode = currentNode;
                currentNode.PreviousNode.NextNode = newNode;
                currentNode.PreviousNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds an element at the beginning of the collection (head)
        /// </summary>
        /// <param name="element"></param>
        public void AddFirst(T element)
        {
            var newHead = new LinkedNode<T>(element);

            if (this.Count == EMPTY_COLLECTION)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds an element at the end of the collection (tail)
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(T element)
        {
            var newTail = new LinkedNode<T>(element);

            if (this.Count == EMPTY_COLLECTION)
            {
                this.tail = this.head = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        /// <summary>
        /// Finds the first node that contains the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedNode<T> Find(T value)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.NextNode;
            }

            return null;
        }

        /// <summary>
        /// Determines whether a value is in the LinkedList<T>
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(element) == 0)
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Removes element after the specified node
        /// </summary>
        /// <param name="node"></param>
        public void RemoveAfter(LinkedNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("The node doesn't exist!");
            }

            if (this.tail == currentNode.NextNode
                || currentNode.NextNode == null)
            {
                this.RemoveLast();
            }
            else
            {
                currentNode.NextNode = currentNode.NextNode.NextNode;
                currentNode.NextNode.PreviousNode = currentNode;
            }

            this.Count--;
        }

        /// <summary>
        /// Removes element before the specified node
        /// </summary>
        /// <param name="node"></param>
        public void RemoveBefore(LinkedNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The node cannot be null!");
            }

            var currentNode = this.Find(node.Value);

            if (currentNode == null)
            {
                throw new InvalidOperationException("The node doesn't exist!");
            }

            if (this.head == currentNode.PreviousNode 
                || currentNode.PreviousNode == null)
            {
                this.RemoveFirst();
            }
            else
            {
                currentNode.PreviousNode.PreviousNode.NextNode = currentNode;
                currentNode.PreviousNode = currentNode.PreviousNode.PreviousNode;
            }

            this.Count--;
        }

        /// <summary>
        /// Removes the element (head) at the beginning of the collection
        /// </summary>
        /// <returns>Removed element or throws Exception</returns>
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException($"The list is empty!");
            }

            var removed = this.head.Value;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PreviousNode = null;
            }

            this.Count--;
            return removed;
        }

        /// <summary>
        /// Removes the element (tail) at the end of the collection
        /// </summary>
        /// <returns>Removed element or throws Exception</returns>
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            var removedElement = this.tail.Value;
            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return removedElement;
        }

        /// <summary>
        /// Goes through the collection and executes a given action
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Returns the collection as an array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            var arr = new T[this.Count];
            var index = 0;

            var currentNode = this.head;
            while (currentNode != null)
            {
                arr[index++] = currentNode.Value;

                currentNode = currentNode.NextNode;
            }

            return arr;
        }

        /// <summary>
        /// Makes our collection foreachable
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Returns GetEnumerator method
        /// </summary>
        /// <returns>GetEnumerator()</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
