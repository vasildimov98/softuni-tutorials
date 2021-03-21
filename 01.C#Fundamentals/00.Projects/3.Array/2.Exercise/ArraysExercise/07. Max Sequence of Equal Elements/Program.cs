using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string maxLength = "";
            for (int i = 0; i < arr.Length; i++)
            {
                int currNum = arr[i];
                string currLength = currNum.ToString() + " ";
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currNum == arr[j])
                    {
                        currLength += arr[j].ToString() + " ";
                    }
                    else
                    {
                        break;
                    }
                }

                if (currLength.Length > maxLength.Length)
                {
                    maxLength = currLength;
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
