using System;

namespace P01.GenericBoxes
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.value}";
        }
    }
}
