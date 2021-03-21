using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            double[] roundedNums = new double[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                roundedNums[i] = Math.Round(nums[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]} => {roundedNums[i]}");
            }
           
        }
    }
}
