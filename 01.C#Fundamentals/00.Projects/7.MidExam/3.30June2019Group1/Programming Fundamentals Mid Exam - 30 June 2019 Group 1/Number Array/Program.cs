using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] allCommands = command
                    .Split();

                string action = allCommands[0];

                if (action == "Switch")
                {
                    SwitchToOposite(arr, allCommands);
                }
                else if (action == "Change")
                {
                    ChangeIndex(arr, allCommands);
                }
                else if (action == "Sum")
                {
                    SumNumbers(arr, allCommands);
                }
            }

            Console.WriteLine(string.Join(" ", arr.Where(a => a >= 0)));
        }

        private static void SumNumbers(int[] arr, string[] allCommands)
        {
            int sum = 0;
            string what = allCommands[1];
            if (what == "Negative")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < 0)
                    {
                        sum += arr[i];
                    }
                }
            }
            else if (what == "Positive")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        sum += arr[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine(sum);
        }

        private static void ChangeIndex(int[] arr, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);
            int number = int.Parse(allCommands[2]);
            if (index >= 0 && index < arr.Length)
            {
                arr[index] = number;
            }
        }

        private static void SwitchToOposite(int[] arr, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);

            if (index >= 0 && index < arr.Length)
            {
                arr[index] *= -1;
            }
        }
    }
}
