using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger snowballSnow = 0;
            BigInteger snowballTime = 0;
            BigInteger snowballQuality = 0;
            BigInteger maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                BigInteger snowballSnow1 = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime1 = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballQuality1 = BigInteger.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow1 / snowballTime1), (int)snowballQuality1);

                if (snowballValue >= maxValue)
                {
                    maxValue = snowballValue;
                    snowballSnow = snowballSnow1;
                    snowballTime = snowballTime1;
                    snowballQuality = snowballQuality1;
                }
            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {maxValue} ({snowballQuality})");
        }
    }
}
