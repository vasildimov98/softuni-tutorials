namespace GenericScale
{
    using System;
    using System.Collections;

    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return this.left.CompareTo(this.right) >= 0;
        }
    }
}
