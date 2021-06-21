namespace PolymorphismDemo
{
    public class Monkey : Mammal
    {
        public Monkey(string name)
            : base(name)
        {

        }

        public override string Breathe()
        {
            return "I am breathing!";
        }
    }
}
