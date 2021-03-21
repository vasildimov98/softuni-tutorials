namespace P02.Graphic_Editor
{
    using P02.Graphic_Editor.Contracts;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape, IDrawingManager drawingManager)
        {
            drawingManager.Draw(shape);
        }
    }
}
