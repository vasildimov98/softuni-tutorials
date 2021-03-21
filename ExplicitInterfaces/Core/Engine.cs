namespace ExplicitInterfaces.Core
{
    using System;
    using System.Linq;
    using ExplicitInterfaces.Contracts;
    using ExplicitInterfaces.IO.Contracts;
    public class Engine : IEngine
    {
        private IReadable reader;
        private IWritable writer;
        public Engine(IReadable readable, IWritable writable)
        {
            this.reader = readable;
            this.writer = writable;
        }
        public void Run()
        {
            CollectAllCitizen();
        }

        private void CollectAllCitizen()
        {
            var command = (string)null;
            while ((command = reader.ReadLine()) != "End")
            {
                var cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = cmdArg[0];
                var country = cmdArg[1];
                var age = int.Parse(cmdArg[2]);

                var citizen = new Citizen(name, age, country);
                PrintResult(citizen);
            }
        }

        private void PrintResult(Citizen citizen)
        {
            IPerson person = citizen;
            IResident resident = citizen;
            writer.WriteLine(person.GetName());
            writer.WriteLine(resident.GetName());
        }
    }
}
