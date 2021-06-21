namespace Zoo
{
    public class Mammal : Animal
    {
        public Mammal(string name) 
            : base(name)
        {
        }
        public new string Name { get; }
    }
}
