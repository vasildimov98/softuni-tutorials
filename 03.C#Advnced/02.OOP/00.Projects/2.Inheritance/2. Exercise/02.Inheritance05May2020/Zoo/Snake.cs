namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string name)
            : base(name)
        {
        }

        public new string Name { get; }
    }
}
