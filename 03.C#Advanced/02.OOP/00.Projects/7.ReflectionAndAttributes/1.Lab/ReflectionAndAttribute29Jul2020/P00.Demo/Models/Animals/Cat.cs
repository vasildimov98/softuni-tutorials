namespace P00.Demo.Models.Animals
{
    public class Cat : Animal
    {
        private const string DEF_NAME = "Garfield";
        private const int DEF_AGE = 0;
        private const double DEF_WEIGHT = 0.50;

        public Cat()
            : base(DEF_NAME, DEF_AGE, DEF_WEIGHT)

        {

        }

        public Cat(string name, int age, double weight)
            : base(name, age, weight)
        {

        }
    }
}
