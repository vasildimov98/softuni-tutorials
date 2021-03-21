namespace P02._DrawingShape_Before
{
    using Contracts;

    public class DrawingRectangleManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            throw new System.NotImplementedException();
        }
    }
}
