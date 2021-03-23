namespace P01.Chronometer
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var chronometer = new Chronometer();

            var command = Console.ReadLine().ToLower();

            while (command != "exit")
            {
                switch (command)
                {
                    case "start":
                        {
                            Task.Run(chronometer.Start);
                        }
                        break;
                    case "stop":
                        Task.Run(chronometer.Stop);
                        break;
                    case "lap":
                        {
                            var lap = chronometer.Lap();

                            Console.WriteLine(lap);
                        }
                        break;
                    case "laps":
                        {
                            var laps = chronometer.Laps;

                            if (laps.Count == 0)
                            {
                                Console.WriteLine("Laps: no laps");
                            }
                            else
                            {
                                Console.WriteLine("Laps:");
                            }

                            for (int i = 0; i < laps.Count; i++)
                            {
                                Console.WriteLine($"{i}. {laps[i]}");
                            }
                        }
                        break;
                    case "time":
                        {
                            var time = chronometer.GetTime;

                            Console.WriteLine(time);
                        }
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }

                command = Console.ReadLine().ToLower();
            }
        }
    }
}
