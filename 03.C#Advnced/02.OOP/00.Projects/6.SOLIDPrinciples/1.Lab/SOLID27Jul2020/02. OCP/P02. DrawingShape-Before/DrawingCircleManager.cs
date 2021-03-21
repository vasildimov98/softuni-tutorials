namespace P02._DrawingShape_Before
{
    using Contracts;

    public class DrawingCircleManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;

            throw new System.NotImplementedException();
        }
    }
}
