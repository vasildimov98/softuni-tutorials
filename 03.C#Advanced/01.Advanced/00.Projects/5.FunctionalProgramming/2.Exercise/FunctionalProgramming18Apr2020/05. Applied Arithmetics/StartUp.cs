using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class StartUp
    {
        static void Main()
        {
            Action<int[]> print = x =>
            {
                Console.WriteLine(string.Join(" ", x));
            };

            var numbers = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string query;
            while ((query = Console.ReadLine()) != "end")
            {
                if (query == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[], int[]> filter = ProcessArray(query);

                    filter(numbers);
                }
            }
        }

        static Func<int[], int[]> ProcessArray(string command)
        {
            Func<int[], int[]> filter = command switch
            {
                "add" => new Func<int[], int[]>(arr =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] + 1;
                    }
                    return arr;
                }),
                "multiply" => new Func<int[], int[]>(arr =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] * 2;
                    }
                    return arr;
                }),
                "subtract" => new Func<int[], int[]>(arr=>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] - 1;
                    }
                    return arr;
                }),
                _ => null
            };

            return filter;
        }

    }
}
