namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string name)
            : base(name)
        {
        }

        public new string Name { get; }
    }
}
