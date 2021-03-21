namespace P03.RecursiveDrawing
{
    using System;
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            DrawFicureWithNumber(number);
        }

        private static void DrawFicureWithNumber(int number)
        {
            if (number == 0) return;

            Console.WriteLine(new string('*', number));
            DrawFicureWithNumber(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}
