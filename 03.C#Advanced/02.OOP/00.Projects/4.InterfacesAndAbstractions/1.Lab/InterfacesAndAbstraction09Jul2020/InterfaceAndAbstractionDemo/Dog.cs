namespace InterfaceAndAbstractionDemo
{
    public class Dog : Mammal, IWalkable
    {
        public Dog(string name, int age)
            : base(name, age)
        {

        }

        public override void Play(string toy)
        {
            System.Console.WriteLine("I am playing with dog's toys");
        }

        public override void Sleep()
        {
            System.Console.WriteLine("I am sleeping like a dog!"); ;
        }

        void IWalkable.Walk()
        {
            System.Console.WriteLine("I am walking int the park...");
        }
    }
}
