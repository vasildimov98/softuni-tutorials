namespace P02.Graphic_Editor.DrawingManagers
{
    using Contracts;

    public abstract class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            this.DrawFigure(shape);
        }

        public abstract void DrawFigure(IShape shape);
    }
}
