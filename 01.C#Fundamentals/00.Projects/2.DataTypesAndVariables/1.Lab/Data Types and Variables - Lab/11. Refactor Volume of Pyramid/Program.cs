using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            Console.Write("Length: ");

            var width = double.Parse(Console.ReadLine());
            Console.Write("Width: ");

            double heigth = double.Parse(Console.ReadLine());
            Console.Write("Height: ");

            var volume = (length * width * heigth) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
