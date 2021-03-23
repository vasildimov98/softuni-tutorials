namespace AsynchronousProgrammingDemo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        //664579 == 664579 == 664579

        private static int countOfPrime;
        private static object primaryCountLock = new object();

        const string END_PROGRAM_COMMAND = "end";
        const string SHOW_RESULT_COMMAND = "show";
        const string TRY_AGAIN_COMMAND = "try";


        public static void Main()
        {
            var sw = Stopwatch.StartNew();
            PrintCountOfPrimeNumbers(0, 10_000_000);
            Console.WriteLine(countOfPrime);
            Console.WriteLine(sw.Elapsed);

            //PrintSumOfAllPrimeNumbers();

            //var sw = Stopwatch.StartNew();

            //var tasks = new List<Task>();
            //for (int i = 1; i <= 100; i++)
            //{
            //    var vicUrl = @$"https://vicove.com/vcat-" + i;
            //    var task = Task.Run(() => DownloadVicFromUrlAsync(vicUrl));

            //    tasks.Add(task);
            //}

            //Task.WaitAll(tasks.ToArray());

            //Console.WriteLine(sw.Elapsed);

            //Console.ReadLine();

            //var sw = Stopwatch.StartNew();

            //var tread1 = new Thread(() => PrintCountOfPrimeNumbers(2, 2_500_000));
            //tread1.Start();

            //var tread2 = new Thread(() => PrintCountOfPrimeNumbers(2_500_001, 5_000_000));
            //tread2.Start();

            //var tread3 = new Thread(() => PrintCountOfPrimeNumbers(5_000_001, 7_500_000));
            //tread3.Start();

            //var tread4 = new Thread(() => PrintCountOfPrimeNumbers(7_500_001, 10_000_000));
            //tread4.Start();

            //tread1.Join();
            //tread2.Join();
            //tread3.Join();
            //tread4.Join();

            //Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(countOfPrime);
        }

        private static void PrintSumOfAllPrimeNumbers()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Sum of all prime numbers of range:");
            Console.Write("Lower number: ");
            var lowerNumber = int.Parse(Console.ReadLine());
            Console.Write("Upper number: ");
            var upperNumber = int.Parse(Console.ReadLine());

            var task = Task
                .Run(() => SumPrimeNumbers(lowerNumber, upperNumber));
            ProccessCommand(task);
        }

        private static void ProccessCommand(Task<long> task)
        {
            var command = Console.ReadLine().Trim().ToLower();

            while (command != END_PROGRAM_COMMAND)
            {
                if (command == SHOW_RESULT_COMMAND)
                {
                    try
                    {
                        var result = task.Result;

                        Console.WriteLine(result);
                    }
                    catch (AggregateException ae)
                    {
                        Console.WriteLine(ae.Message);

                        Console.WriteLine("Sum of all prime numbers of range:");
                        Console.Write("Lower number: ");
                        var lowerNumber = int.Parse(Console.ReadLine());
                        Console.Write("Upper number: ");
                        var upperNumber = int.Parse(Console.ReadLine());

                        task = Task
                            .Run(() => SumPrimeNumbers(lowerNumber, upperNumber));
                    }
                }
                else if (command == TRY_AGAIN_COMMAND)
                {
                    Console.WriteLine("Sum of all prime numbers of range:");
                    Console.Write("Lower number: ");
                    var lowerNumber = int.Parse(Console.ReadLine());
                    Console.Write("Upper number: ");
                    var upperNumber = int.Parse(Console.ReadLine());

                    task = Task
                        .Run(() => SumPrimeNumbers(lowerNumber, upperNumber));
                }

                command = Console.ReadLine().Trim().ToLower();
            }
        }

        private static long SumPrimeNumbers(int start, int end)
        {
            if (start < 2) start = 2;

            if (end < start)
            {
                throw new InvalidOperationException("Upper number should be bigger than lower number! Try again");
            }


            var sum = 0L;
            for (int i = start; i < end; i++)
            {
                var isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) sum += i;
            }

            return sum;
        }

        private static async Task DownloadVicFromUrlAsync(string vicUrl)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(vicUrl);
            var vic = await response.Content.ReadAsStringAsync();
            Console.WriteLine(vic.Length);
        }

        //private static void DownloadVicFromUrl(string vicUrl)
        //{
        //    var client = new HttpClient();
        //    client.GetAsync(vicUrl).ContinueWith(response => 
        //    {
        //        response.Result.Content.ReadAsStringAsync().ContinueWith(vic =>
        //        {
        //            Console.WriteLine(vic.Result.Length);
        //        });
        //    });
        //}

        private static void PrintCountOfPrimeNumbers(int min, int max)
        {
            if (min < 2) min = 2;

            //for (int i = min; i <= max; i++)
            Parallel.For(min, max + 1, i =>
            {
                var isPrime = true;
                var sqr = Math.Sqrt(i);
                for (int j = 2; j <= sqr; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    lock (primaryCountLock)
                    {
                        countOfPrime++;
                    }
                }
            });
        }
    }
}
