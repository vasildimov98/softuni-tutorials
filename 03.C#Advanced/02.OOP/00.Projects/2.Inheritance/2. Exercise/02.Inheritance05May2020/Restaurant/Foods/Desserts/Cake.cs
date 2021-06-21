namespace Restaurant.Foods.Desserts
{
    public class Cake : Dessert
    {
        private const decimal CAKE_PRICE = 5m;
        private const double CAKE_GRAMS = 250;
        private const double CALORIES = 1000;
        public Cake(string name)
            : base(name, CAKE_PRICE, CAKE_GRAMS, CALORIES)
        {

        }
    }
}
