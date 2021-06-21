namespace P00.GenericsDemo
{
    using System.Collections.Generic;

    public class MyStack<T> 
        where T : struct
    {
        private List<T> list = new List<T>();

        public void Add(T element)
        {
            this.list.Add(element);
        }
    }
}
