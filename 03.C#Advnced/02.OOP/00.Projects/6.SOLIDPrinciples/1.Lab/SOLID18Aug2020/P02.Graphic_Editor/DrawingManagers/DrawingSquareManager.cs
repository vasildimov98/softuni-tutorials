namespace P02.Graphic_Editor.DrawingManagers
{
    using System;

    using Contracts;

    public class DrawingSquareManager : DrawingManager
    {
        public override void DrawFigure(IShape shape)
        {
            var square = shape as Square;

            Console.WriteLine($"I am {square.GetType().Name}");
        }
    }
}
