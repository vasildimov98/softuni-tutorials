namespace SimpleSnake.GameObjects.Points.Foods
{
    using Points.Contracts;

    public class FoodHash : Food
    {
        private const char FOOD_SYMBOL = '#';
        private const int FOOD_POINTS = 3;

        public FoodHash(IPoint wall)
            : base(wall, FOOD_SYMBOL, FOOD_POINTS)
        {

        }
    }
}
