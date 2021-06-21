using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWeendow = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var count = 0;
            string command;
            var crashedCar = "";
            var index = 0;
            var flag = true;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    var currDuration = greenLightDuration;

                    while (currDuration > 0 && queue.Any())
                    {
                        var currCar = queue.Peek();

                        currDuration -= currCar.Length;

                        if (currDuration >= 0)
                        {
                            queue.Dequeue();
                            count++;
                        }
                        else
                        {
                            var left = Math.Abs(currDuration);

                            if (left <= freeWeendow)
                            {
                                queue.Dequeue();
                                count++;
                            }
                            else
                            {
                                crashedCar = currCar;
                                index = currCar.Length - left + freeWeendow;
                                flag = false;
                            }
                        }
                    }

                    if (!flag)
                    {
                        break;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[index]}.");
            }
            
        }
    }
}
