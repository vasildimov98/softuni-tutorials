namespace P00.Demo.Models.Animals
{
    public class Dog : Animal
    {
        private const string DEF_NAME = "Sharo";
        private const int DEF_AGE = 0;
        private const double DEF_WEIGHT = 1.50;

        public Dog()
            : base(DEF_NAME, DEF_AGE, DEF_WEIGHT)

        {

        }

        public Dog(string name, int age, double weight)
            : base(name, age, weight)
        {

        }
    }
}
