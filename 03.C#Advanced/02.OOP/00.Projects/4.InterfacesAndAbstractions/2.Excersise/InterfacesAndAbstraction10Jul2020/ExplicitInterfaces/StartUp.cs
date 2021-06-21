using System;
using System.Linq;
using System.Threading;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var citizenArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = citizenArgs[0];
                var country = citizenArgs[1];
                var age = int.Parse(citizenArgs[2]);

                var citizen = new Citizen(name, country, age);

                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}
