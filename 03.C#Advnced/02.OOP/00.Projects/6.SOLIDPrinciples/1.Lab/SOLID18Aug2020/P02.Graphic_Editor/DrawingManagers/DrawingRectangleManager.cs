namespace P02.Graphic_Editor.DrawingManagers
{
    using System;

    using Contracts;

    public class DrawingRectangleManager : DrawingManager
    {
        public override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            Console.WriteLine($"I am {rectangle.GetType().Name}"); 
        }
    }
}
