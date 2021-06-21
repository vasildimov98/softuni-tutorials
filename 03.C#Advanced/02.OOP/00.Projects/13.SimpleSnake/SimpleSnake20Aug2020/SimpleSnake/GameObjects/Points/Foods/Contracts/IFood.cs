namespace SimpleSnake.GameObjects.Points.Foods.Contracts
{
    using System.Collections.Generic;

    using Points.Contracts;

    public interface IFood
    {
        int FoodPoints { get; }

        void SetRandomPosition(Queue<IPoint> snakeElements);

        bool IsFoodPoint(IPoint snake);
    }
}
