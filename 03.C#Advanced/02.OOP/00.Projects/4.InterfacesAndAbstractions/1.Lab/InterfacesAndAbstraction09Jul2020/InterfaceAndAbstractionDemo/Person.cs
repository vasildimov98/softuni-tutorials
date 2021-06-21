namespace InterfaceAndAbstractionDemo
{
    public class Person : Mammal
    {
        public Person(string name, int age)
            : base(name, age)
        {

        }

        public override void Play(string toy)
        {
            System.Console.WriteLine("I am playng with human toys");
        }
    }
}
