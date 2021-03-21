using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main()
        {
            List<string> ownedTanked = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] allCommand = Console
                    .ReadLine()
                    .Split(", ");

                string action = allCommand[0];

                if (action == "Add")
                {
                    AddTank(ownedTanked, allCommand);
                }
                else if (action == "Remove")
                {
                    RemoveTank(ownedTanked, allCommand);
                }
                else if (action == "Remove At")
                {
                    RemoveAt(ownedTanked, allCommand);
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(allCommand[1]);
                    string tankNamed = allCommand[2];
                    if (index < 0 || index >= ownedTanked.Count)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }
                    else
                    {
                        if (ownedTanked.Contains(tankNamed))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            ownedTanked.Insert(index, tankNamed);
                            Console.WriteLine("Tank successfully bought");
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", ownedTanked));
        }

        private static void RemoveAt(List<string> ownedTanked, string[] allCommand)
        {
            int index = int.Parse(allCommand[1]);

            if (index >= 0 && index < ownedTanked.Count)
            {
                Console.WriteLine("Tank successfully sold");
                ownedTanked.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }

        private static void RemoveTank(List<string> ownedTanked, string[] allCommand)
        {
            string tankName = allCommand[1];
            if (ownedTanked.Contains(tankName))
            {
                Console.WriteLine("Tank successfully sold");
                ownedTanked.Remove(tankName);
            }
            else
            {
                Console.WriteLine("Tank not found");
            }
        }

        private static void AddTank(List<string> ownedTanked, string[] allCommand)
        {
            string tankNamed = allCommand[1];

            if (ownedTanked.Contains(tankNamed))
            {
                Console.WriteLine($"Tank is already bought");
            }
            else
            {
                ownedTanked.Add(tankNamed);
                Console.WriteLine($"Tank successfully bought");
            }
        }
    }
}
