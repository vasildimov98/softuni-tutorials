namespace SimpleSnake
{
    using Core;
    using Utilities;
    using GameObjects.Points;

    public class StartUp
    {
        public static void Main()
        {
            var leftX = 60;
            var topY = 20;
            ConsoleWindow.CustomizeConsole();

            var wall = new Wall(leftX, topY);
            var snake = new Snake(wall);

            var engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
