using System;
using System.Collections.Generic;

namespace P01.ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            string command;
            var listIterator = new ListyIterator<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var action = data[0];

                if (action == "Create" && data.Length > 1)
                {
                    var list = new List<string>();
                    for (int i = 1; i < data.Length; i++)
                    {
                        list.Add(data[i]);
                    }
                   listIterator = new ListyIterator<string>(list);
                }
                else if (action == "Move")
                {
                    Console.WriteLine(listIterator.Move());
                }
                else if (action == "Print")
                {
                    listIterator.Print();
                }
                else if (action == "HasNext")
                {
                    Console.WriteLine(listIterator.HasNext());
                }
            }
        }
    }
}
