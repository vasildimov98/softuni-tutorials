namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal CakePrice = 5;
        private const double Grams = 250;
        private const double Calories = 1000;

        public Cake(string name)
            : base(name, CakePrice, Grams, Calories)
        {

        }
    }
}
