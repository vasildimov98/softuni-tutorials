namespace SimpleSnake.GameObjects.Points.Contracts
{
    public interface IPoint
    {
        int LeftX { get; }
        int TopY { get; }

        void Draw(char symbol);
        void Draw(int leftX, int topY, char symbol);
    }
}
