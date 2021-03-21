namespace PolymorphismDemo
{
    public class Square : Rectangle
    {
        private readonly int a;

        public override int Area()
        {
            return a * a;
        }
    }
}
