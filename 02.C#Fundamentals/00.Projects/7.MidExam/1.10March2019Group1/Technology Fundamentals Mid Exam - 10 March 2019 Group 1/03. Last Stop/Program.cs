using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] allCommand = command
                    .Split();

                string action = allCommand[0];
                if (action == "Change")
                {
                    int paintingNumber = int.Parse(allCommand[1]);
                    int changedNumber = int.Parse(allCommand[2]);

                    if (paintings.Contains(paintingNumber))
                    {
                        int index = paintings.IndexOf(paintingNumber);

                        paintings[index] = changedNumber;
                    }
                }
                else if (action == "Hide")
                {
                    int paintingNumber = int.Parse(allCommand[1]);
                    if (paintings.Contains(paintingNumber))
                    {
                        paintings.Remove(paintingNumber);
                    }
                }
                else if (action == "Switch")
                {
                    int paintingNumber1 = int.Parse(allCommand[1]);
                    int paintingNumber2 = int.Parse(allCommand[2]);

                    if (paintings.Contains(paintingNumber1) && paintings.Contains(paintingNumber2))
                    {
                        int index1 = paintings.IndexOf(paintingNumber1);
                        int index2 = paintings.IndexOf(paintingNumber2);

                        int temp = paintings[index1];
                        paintings[index1] = paintings[index2];
                        paintings[index2] = temp;
                    }
                }
                else if (action == "Insert")
                {
                    int place = int.Parse(allCommand[1]) + 1;
                    int paintingNumber = int.Parse(allCommand[2]);
                    if (place >= 0 && place <= paintings.Count)
                    {
                        paintings.Insert(place, paintingNumber);
                    }
                }
                else if (action == "Reverse")
                {
                    paintings.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", paintings));
        }
    }
}
