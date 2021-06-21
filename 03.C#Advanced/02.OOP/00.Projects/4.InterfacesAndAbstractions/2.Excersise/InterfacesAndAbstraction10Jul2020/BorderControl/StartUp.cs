namespace BorderControl
{
    using System;
    using System.Linq;
    using System.Collections.ObjectModel;

    public class StartUp
    {
        public static void Main()
        {
            var citizens = new Collection<IPerson>();

            var numberOfPeopleToReceive = int.Parse(Console.ReadLine());

            AddRebelAndCitizens(citizens, numberOfPeopleToReceive);

            BuyFood(citizens);

            Console.WriteLine(citizens.Sum(p => p.Food));
        }

        private static void BuyFood(Collection<IPerson> citizens)
        {
            string currName;
            while ((currName = Console.ReadLine()) != "End")
            {
                var person = citizens
                    .FirstOrDefault(p => p.Name == currName);

                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }

        private static void AddRebelAndCitizens(Collection<IPerson> citizens, int numberOfPeopleToReceive)
        {
            for (int i = 0; i < numberOfPeopleToReceive; i++)
            {
                var args = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

                if (args.Length == 4)
                {
                    var name = args[0];
                    var age = int.Parse(args[1]);
                    var id = args[2];
                    var birthdate = args[3];

                    var citizen = new Citizen(name, age, id, birthdate);

                    citizens.Add(citizen);
                }
                else
                {
                    var name = args[0];
                    var age = int.Parse(args[1]);
                    var group = args[2];

                    var rebel = new Rebel(name, age, group);

                    citizens.Add(rebel);
                }
            }
        }
    }
}
