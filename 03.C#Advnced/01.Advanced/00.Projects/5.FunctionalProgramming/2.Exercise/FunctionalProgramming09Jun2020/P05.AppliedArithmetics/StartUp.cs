namespace P05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Action<int[]> printer = c => Console.WriteLine(string.Join(" ", c));

            var collection = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            OperateOnCommand(printer, collection);
        }

        private static void OperateOnCommand(Action<int[]> printer, int[] collection)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    CallBackPrint(collection, printer);
                }
                else
                {
                    var func = GetRightFunc(command);

                    func(collection);
                }
            }
        }

        private static void CallBackPrint(int[] arr, Action<int[]> printer)
        {
            printer(arr);
        }

        private static Func<int[], int[]> GetRightFunc(string con)
        {
            if (con == "add")
            {
                return c =>
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i] += 1;
                    }

                    return c;
                };
            }
            else if (con == "multiply")
            {
                return c =>
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i] *= 2;
                    }

                    return c;
                };
            }
            else 
            {
                return c =>
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i] -= 1;
                    }

                    return c;
                };
            }
        }
    }
}
