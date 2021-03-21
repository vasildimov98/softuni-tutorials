namespace SimpleSnake.GameObjects.Points.Foods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Points.Contracts;

    public abstract class Food : Point, IFood
    {
        private const int MIN_SET_POSITION = 2;

        private readonly char foodSymbol;
        private readonly IPoint wall;
        private readonly Random random;

        protected Food(IPoint wall, char foodSymbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;

            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<IPoint> snakeElements)
        {
            var isPointOfSnake = false;

            do
            {
                base.LeftX = this.random.Next(MIN_SET_POSITION, this.wall.LeftX - MIN_SET_POSITION);

                base.TopY = this.random.Next(MIN_SET_POSITION, this.wall.TopY - MIN_SET_POSITION);

                isPointOfSnake = snakeElements
                .Any(el => el.LeftX == base.LeftX
                && el.TopY == base.TopY);

            } while (isPointOfSnake);

            Console.BackgroundColor = ConsoleColor.Green;
            base.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(IPoint snake)
        {
            return base.LeftX == snake.LeftX 
                && base.TopY == snake.TopY;
        }
    }
}
