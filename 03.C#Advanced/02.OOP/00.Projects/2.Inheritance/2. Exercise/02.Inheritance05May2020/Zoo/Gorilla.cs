namespace Zoo
{
    public class Gorilla : Mammal
    {
        public Gorilla(string name)
            : base(name)
        {
        }
        public new string Name { get; }
    }
}
