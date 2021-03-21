using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console
                .ReadLine()
                .Split("&")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] data = command.Split(" | ");

                if (data[0] == "Add Book")
                {
                    if (!books.Contains(data[1]))
                    {
                        books.Insert(0, data[1]);
                    }
                }
                else if (data[0] == "Take Book")
                {
                    if (books.Contains(data[1]))
                    {
                        books.Remove(data[1]);
                    }
                }
                else if (data[0] == "Swap Books")
                {
                    if (books.Contains(data[1]) && books.Contains(data[2]))
                    {
                        books[books.IndexOf(data[2])] = data[1];
                        books[books.IndexOf(data[1])] = data[2];
                    }
                }
                else if (data[0] == "Insert Book")
                {
                    books.Add(data[1]);
                }
                else if (data[0] == "Check Book")
                {
                    int index = int.Parse(data[1]);

                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
