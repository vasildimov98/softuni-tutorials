using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Bit_Destroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(n, 2).ToString();

            List<char> list = binary.ToCharArray().ToList();

            if (p < list.Count)
            {
                list[p] = '0'; 
            }

            binary = "";
            list.Reverse();
            foreach (var item in list)
            {
                binary += item;
            }

            int number = Convert.ToInt32(binary, 2);

            Console.WriteLine(number);
        }
    }
}
