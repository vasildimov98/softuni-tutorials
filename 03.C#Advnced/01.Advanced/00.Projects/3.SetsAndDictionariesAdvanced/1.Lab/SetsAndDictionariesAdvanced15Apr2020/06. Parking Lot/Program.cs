using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var hashSet = new HashSet<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (data[0] == "IN")
                {
                    hashSet.Add(data[1]);
                }
                else if (data[0] == "OUT")
                {
                    hashSet.Remove(data[1]);
                }
            }

            if (hashSet.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, hashSet));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            } 
        }
    }
}
