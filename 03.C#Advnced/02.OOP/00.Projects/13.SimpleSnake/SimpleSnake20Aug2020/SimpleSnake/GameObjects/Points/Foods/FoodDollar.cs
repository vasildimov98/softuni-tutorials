namespace SimpleSnake.GameObjects.Points.Foods
{
    using Points.Contracts;

    public class FoodDollar : Food
    {
        private const char FOOD_SYMBOL = '$';
        private const int FOOD_POINTS = 2;

        public FoodDollar(IPoint wall)
            : base(wall, FOOD_SYMBOL, FOOD_POINTS)
        {

        }
    }
}
