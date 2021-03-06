using System;
using System.Collections.Generic;

namespace P02.Collection
{
    class StartUp
    {
        static void Main()
        {
            string command;
            var listy = new ListyIterator<string>();
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

                    listy = new ListyIterator<string>(list);
                }
                else if (action == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (action == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (action == "Print")
                {
                    listy.Print();
                }
                else if (action == "PrintAll")
                {
                    listy.PrintAll();
                }
            }
        }
    }
}
