using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double heighestVolume = 0;
            string heighestVolumeModel = "";
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int heigth = int.Parse(Console.ReadLine());

                double volume = 3.14 * Math.Pow(radius,2) * heigth;
                if (volume > heighestVolume)
                {
                    heighestVolume = volume;
                    heighestVolumeModel = model;
                }
            }

            Console.WriteLine(heighestVolumeModel);
        }
    }
}
