using System;
using System.Linq;

namespace P02.PointinRectangle
{
    class StartUp
    {
        static void Main()
        {
            var coordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var topLeftX = coordinates[0];
            var topLeftY = coordinates[1];

            var topRightX = coordinates[2];
            var topRightY = coordinates[3];

            var topLeftPoint = new Point(topLeftX, topLeftY);
            var topRightPoint = new Point(topRightX, topRightY);

            var rectangle = new Rectangle(topLeftPoint, topRightPoint);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var pointX = line[0];
                var pointY = line[1];

                var point = new Point(pointX, pointY);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
