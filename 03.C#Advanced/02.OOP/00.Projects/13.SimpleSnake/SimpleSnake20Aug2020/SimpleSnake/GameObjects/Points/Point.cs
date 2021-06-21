namespace SimpleSnake.GameObjects.Points
{
    using System;

    using Contracts;

    public class Point : IPoint
    {
        public Point(int leftX, int topY)
        {
           this.LeftX = leftX;
           this.TopY = topY;
        }

        public int LeftX { get; protected set; }

        public int TopY { get; protected set; }

        public void Draw(char symbol)
        {
            this.Draw(this.LeftX, this.TopY, symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
