namespace _01.Hierarchy
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private const string NON_EXISTING_ELEMENT_MSG
            = "There is no such element in the hierarchy!!!";

        private readonly Node<T> root;
        private readonly Dictionary<T, Node<T>> nodesByValue;

        public Hierarchy(T defaultRoot)
        {
            this.root = new Node<T>(defaultRoot);

            this.nodesByValue = new Dictionary<T, Node<T>>
            {
                [defaultRoot] = this.root
            };
        }

        public int Count => this
            .nodesByValue
            .Count;

        public void Add(T parentValue, T childValue)
        {
            var parentMsg = "There is no such parent in the hierarchy!!!";
            this.ValidateIsNotContain(parentValue, parentMsg);

            var childMsg = "There is no such child in the hierarchy!!!";
            this.ValidateIsContain(childValue, childMsg);

            var parentNode = this.nodesByValue[parentValue];
            var childNode = new Node<T>(childValue, parentNode);
            parentNode.Children.Add(childNode);

            this.nodesByValue[childValue] = childNode;
        }

        public void Remove(T element)
        {
            this.ValidateIsNotContain(element, NON_EXISTING_ELEMENT_MSG);

            var elementToRemove = this.nodesByValue[element];
            this.ValidateIsRoot(elementToRemove);

            var elementParent = elementToRemove
                .Parent;
            var elementChildren = elementToRemove
                .Children;

            foreach (var child in elementChildren)
            {
                child.Parent = elementParent;
                elementParent.Children.Add(child);
            }

            elementParent
                .Children
                .Remove(elementToRemove);

            this.nodesByValue.Remove(element);
        }

        public bool Contains(T element)
           => this.nodesByValue
               .ContainsKey(element);

        public T GetParent(T element)
        {
            this.ValidateIsNotContain(element, NON_EXISTING_ELEMENT_MSG);

            var parentNode = this.nodesByValue[element].Parent;

            return parentNode == null ? default :
                this.nodesByValue[element].Parent.Value;
        }

        public IEnumerable<T> GetChildren(T element)
        {
            this.ValidateIsNotContain(element, NON_EXISTING_ELEMENT_MSG);

            var parentNode = this.nodesByValue[element];

            return parentNode
                .Children
                .Select(ch => ch.Value);
        }


        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            //var result = new List<T>();

            //foreach (var element in other)
            //{
            //    if (this.nodesByValue.ContainsKey(element))
            //    {
            //        result.Add(element);
            //    }
            //}

            //return result;

            var result = new HashSet<T>(this.nodesByValue.Keys);
            result.IntersectWith(new HashSet<T>(other));
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var currElement = queue.Dequeue();

                yield return currElement.Value;

                foreach (var child in currElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIsRoot(Node<T> elementNode)
        {
            if (elementNode.Parent == null)
            {
                throw new InvalidOperationException("You cannot remove the root of the hierarchy!!!");
            }
        }

        private void ValidateIsContain(T arg, string msg)
        {
            if (this.Contains(arg))
            {
                throw new ArgumentException(msg);
            }
        }

        private void ValidateIsNotContain(T arg, string msg)
        {
            if (!this.Contains(arg))
            {
                throw new ArgumentException(msg);
            }
        }
    }
}