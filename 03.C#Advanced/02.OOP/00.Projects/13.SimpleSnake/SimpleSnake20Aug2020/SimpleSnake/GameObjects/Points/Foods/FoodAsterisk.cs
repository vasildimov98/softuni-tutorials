namespace SimpleSnake.GameObjects.Points.Foods
{
    using Points.Contracts;

    public class FoodAsterisk : Food
    {
        private const char FOOD_SYMBOL = '*';
        private const int FOOD_POINTS = 1;

        public FoodAsterisk(IPoint wall)
            : base(wall, FOOD_SYMBOL, FOOD_POINTS)
        {

        }
    }
}
