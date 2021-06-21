namespace P02.Graphic_Editor.DrawingManagers
{
    using System;
    using Contracts;

    public class DrawingCircleManager : DrawingManager
    {
        public override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;

            Console.WriteLine($"I am {circle.GetType().Name}");
        }
    }
}
