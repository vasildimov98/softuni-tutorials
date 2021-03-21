using System;

namespace _1._Giftbox_Coverage
{
    class Program
    {
        static void Main()
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            int numberOfSheetsOfPaper = int.Parse(Console.ReadLine());
            double areaCoverPerSheet = double.Parse(Console.ReadLine());

            double areaOfGiftBox = Math.Pow(sizeOfSide, 2)*6;

            double lessCover = numberOfSheetsOfPaper / 3;
            double normalCover = numberOfSheetsOfPaper - lessCover;

            double totalCover = (lessCover * (areaCoverPerSheet * 0.25)) + (normalCover * areaCoverPerSheet);

            double percentege = Math.Abs(totalCover / areaOfGiftBox * 100);

            Console.WriteLine($"You can cover {percentege:F2}% of the box.");
        }
    }
}
