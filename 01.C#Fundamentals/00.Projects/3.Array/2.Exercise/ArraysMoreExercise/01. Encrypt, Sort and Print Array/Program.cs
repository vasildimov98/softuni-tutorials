using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            double[] sums = new double[n];
            for (int i = 0; i < n; i++)
            {
                names[i] = Console.ReadLine();
                string name = names[i];
                double sum = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    char letter = name[j];
                    bool isVowel = "aeiouAEIOU".IndexOf(letter) >= 0;

                    if (isVowel)
                    {
                        sum += letter * name.Length;
                    }
                    else
                    {
                        sum += letter / name.Length;
                    }
                }

                sums[i] = sum;
            }

            sums = sums.OrderBy(a => a).ToArray();
            foreach (var sum in sums)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
