namespace P02.RecursiveDrawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            DrawFigure(rows);
        }

        private static void DrawFigure(int rows)
        {
            if (rows == 0) return;

            Console.WriteLine(new string('*', rows));
            DrawFigure(rows - 1);
            Console.WriteLine(new string('#', rows));
        }
    }
}
