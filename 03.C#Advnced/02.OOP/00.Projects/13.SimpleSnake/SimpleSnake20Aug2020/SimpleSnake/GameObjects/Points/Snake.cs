namespace SimpleSnake.GameObjects.Points
{
    using System.Linq;
    using System.Collections.Generic;

    using Foods;
    using Contracts;
    using System;
    using SimpleSnake.GameObjects.Points.Foods.Contracts;

    public class Snake : Point
    {
        private const char SNAKE_SYMBOL = '\u25CF';
        private const char EMPTY_SPACE = ' ';
        private const int INIT_MAX_SNAKE_BODY_LEN = 6;
        private const int MIN_LEFT_X = 2;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private int pointsNeededToLevelUp;

        private readonly IPoint wall;

        private readonly Queue<IPoint> snakeElements;
        private readonly IFood[] foods;

        public Snake(IPoint wall)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.pointsNeededToLevelUp = 2;

            this.snakeElements = new Queue<IPoint>();
            this.foods = new IFood[3];

            this.GetFoods();
            this.SetFood();
            this.CreateSnake();
        }

        public int Points { get; private set; }
        public int Level { get; private set; }
        private int RandomFoodIndex
            => new Random().Next(0, this.foods.Length);

        public bool IsMoving(IPoint direction)
        {
            var snakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, snakeHead);

            var IsBeatedByHerself = this.snakeElements
                .Any(p => p.LeftX == this.nextLeftX
                && p.TopY == this.nextTopY);

            if (IsBeatedByHerself)
            {
                return false;
            }

            var snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SNAKE_SYMBOL);

            if (this.foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeNewHead);
            }

            var prevDotPoint = this.snakeElements.Dequeue();
            prevDotPoint.Draw(EMPTY_SPACE);

            return true;
        }

        private void Eat(IPoint direction, Point currSnakeHead)
        {
            var food = this.foods[this.foodIndex];
            var foodPoint = food.FoodPoints;

            this.LevelUp(foodPoint);

            this.MakeTheSnakeLonger(direction, currSnakeHead, foodPoint);

            this.SetFood();
        }

        private void MakeTheSnakeLonger(IPoint direction, Point currSnakeHead, int foodPoint)
        {
            for (int i = 0; i < foodPoint; i++)
            {
                this.snakeElements
                    .Enqueue(new Point(this.nextLeftX, nextTopY));
                this.GetNextPoint(direction, currSnakeHead);
            }
        }

        private void LevelUp(int foodPoint)
        {
            this.Points += foodPoint;

            if (this.Points >= this.pointsNeededToLevelUp)
            {
                this.Level++;
                this.pointsNeededToLevelUp += 2;
            }
        }

        private void SetFood()
        {
            this.foodIndex = this.RandomFoodIndex;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= INIT_MAX_SNAKE_BODY_LEN; topY++)
            {
                this.snakeElements.Enqueue(new Point(MIN_LEFT_X, topY));
            }
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }

        private void GetNextPoint(IPoint direction, IPoint snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private bool IsPointOfWall(IPoint snake)
        {
            return snake.LeftX == 0
                || snake.TopY == 0
                || snake.LeftX == this.LeftX - 1
                || snake.TopY == this.TopY;
        }
    }
}
