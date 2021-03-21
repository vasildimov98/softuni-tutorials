using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                List<string> list = command.Split(" ").ToList();
                string name = list[0];
                NewMethod(guests, list, name);
            }

            foreach(string name in guests)
            {
                Console.WriteLine(name);
            }
        }

        static void NewMethod(List<string> guests, List<string> list, string name)
        {
            if (list.Count == 3)
            {
                bool isInTheList = true;
                foreach (string elm in guests)
                {
                    if (elm == name)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        isInTheList = false;
                        break;
                    }
                }

                if (isInTheList)
                {
                    guests.Add(name);
                }
            }
            else
            {
                bool isNotInTheList = true;
                foreach (string elm in guests)
                {
                    if (elm == name)
                    {
                        guests.Remove(name);
                        isNotInTheList = false;
                        break;
                    }
                }

                if (isNotInTheList)
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }
    }
}
