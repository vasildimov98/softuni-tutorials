namespace P08.TrafficJam
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var countOfCarsThatCouldPass = int.Parse(Console.ReadLine());

            var countOfCarThatPassedSuccessfully = 0;

            var cars = new Queue<string>();
            countOfCarThatPassedSuccessfully
                = GetGreenLightPasses(countOfCarsThatCouldPass, countOfCarThatPassedSuccessfully, cars);

            Console.WriteLine($"{countOfCarThatPassedSuccessfully} cars passed the crossroads.");
        }

        private static int GetGreenLightPasses(int countOfCarsThatCouldPass, int countOfCarThatPassedSuccessfully, Queue<string> cars)
        {
            string commad;
            while ((commad = Console.ReadLine()) != "end")
            {
                if (commad == "green")
                {
                    for (int i = 0; i < countOfCarsThatCouldPass; i++)
                    {
                        if (!cars.Any())
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countOfCarThatPassedSuccessfully++;
                    }

                    continue;
                }

                cars.Enqueue(commad);
            }

            return countOfCarThatPassedSuccessfully;
        }
    }
}
