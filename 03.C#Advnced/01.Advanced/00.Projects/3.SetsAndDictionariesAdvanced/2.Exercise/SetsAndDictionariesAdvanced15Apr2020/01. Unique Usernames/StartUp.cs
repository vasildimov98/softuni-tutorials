﻿using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
            
        }
    }
}
