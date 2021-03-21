using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class StartUp
    {
        static void Main()
        {
            string command;

            var regular = new HashSet<string>();
            var VIP = new HashSet<string>();

            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    VIP.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(command[0]))
                {
                    VIP.Remove(command);
                }
                else
                {
                    regular.Remove(command);
                }
            }

            Console.WriteLine(regular.Count + VIP.Count);
            if (VIP.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, VIP));
            }

            if (regular.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regular));
            }
        }
    }
}
