﻿using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char indexI = (char)('a' + i);
                        char indexJ = (char)('a' + j);
                        char indexK = (char)('a' + k);
                        Console.WriteLine("" + indexI + indexJ + indexK);
                    }
                }
            }
        }
    }
}
