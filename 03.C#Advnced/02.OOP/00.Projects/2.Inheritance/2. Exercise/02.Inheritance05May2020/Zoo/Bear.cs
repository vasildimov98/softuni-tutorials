namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string name)
            : base(name)
        {
        }

        public new string Name { get; }
    }
}
