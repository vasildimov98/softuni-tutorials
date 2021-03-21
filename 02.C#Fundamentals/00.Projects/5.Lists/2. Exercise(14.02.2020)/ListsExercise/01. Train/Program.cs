using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = "";

            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", wagons));
                    return;
                }
                List<string> allCommand = command
                    .Split()
                    .ToList();

                if (allCommand.Count == 2)
                {
                    int number = int.Parse(allCommand[1]);
                    GetNewList(wagons, number);
                }
                else
                {
                    int passengers = int.Parse(allCommand[0]);
                    int number = 0;
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        number = wagons[i];
                        if (passengers <= (maxCapacity - number))
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }
        }

        static void GetNewList(List<int> wagons, int num)
        {
            wagons.Add(num);
        }
    }
}
