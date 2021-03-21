namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private readonly Stack<T> elements;

        public Box()
        {
            this.elements = new Stack<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Push(element);
        }

        public T Remove()
        {
            var element = this.elements.Pop();

            return element;
        }
    }
}
