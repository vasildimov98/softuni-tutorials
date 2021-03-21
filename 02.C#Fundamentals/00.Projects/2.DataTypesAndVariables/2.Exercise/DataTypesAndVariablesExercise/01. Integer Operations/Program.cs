using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            // when a int reach the max Value it overflows 
           
           int numFirst = int.Parse(Console.ReadLine());
           int numSecond = int.Parse(Console.ReadLine());
           int numThird = int.Parse(Console.ReadLine());
           int numFourth = int.Parse(Console.ReadLine());

            double sum = ((numFirst + numSecond) / numThird) * numFourth;

            Console.WriteLine(sum);
        }  
    }
}
