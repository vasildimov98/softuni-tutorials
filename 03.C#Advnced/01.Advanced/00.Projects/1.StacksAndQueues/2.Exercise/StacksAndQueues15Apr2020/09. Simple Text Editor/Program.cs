using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var undoneOperation = new Stack<string>();

            var text = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var data = Console
                    .ReadLine()
                    .Split(' ', 2)
                    .ToArray();

                if (data[0] == "1")
                {
                    undoneOperation.Push(text.ToString());
                    text.Append(data[1]);
                }

                if (data[0] == "2")
                {
                    undoneOperation.Push(text.ToString());
                    var length = int.Parse(data[1]);
                    text.Remove(text.Length - length, length);
                }

                if (data[0] == "3")
                {
                    var index = int.Parse(data[1]);
                    Console.WriteLine(text[index - 1]);
                }

                if (data[0] == "4")
                {
                    text.Clear();

                    var last = undoneOperation.Pop();
                    text.Append(last);
                }
            }
        }
    }
}
