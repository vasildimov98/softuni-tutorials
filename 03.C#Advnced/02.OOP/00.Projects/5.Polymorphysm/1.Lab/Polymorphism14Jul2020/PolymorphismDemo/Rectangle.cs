namespace PolymorphismDemo
{
    public class Rectangle
    {
        private readonly int a;
        private readonly int b;

        public virtual int Area()
        {
            return a * b;
        }

    }
}
