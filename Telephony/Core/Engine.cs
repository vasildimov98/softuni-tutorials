namespace Telephony.Core
{
    using System;
    using System.Linq;
    using Telephony.Contracts;
    using Telephony.Exeptions;
    using Telephony.IO.Contracts;
    using Telephony.Models;

    public class Engine : IEngine
    {
        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        private IReadable reader;
        private IWritable writer;
        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReadable reader, IWritable writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            CallNumbers();
            BrowseTheInternet();
        }

        private void BrowseTheInternet()
        {
            var urls = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidURLExeption msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }

        private void CallNumbers()
        {
            var numbers = reader
                .ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(this.stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        writer.WriteLine(this.smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberExeption();
                    }
                }
                catch (InvalidNumberExeption msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }
    }
}
