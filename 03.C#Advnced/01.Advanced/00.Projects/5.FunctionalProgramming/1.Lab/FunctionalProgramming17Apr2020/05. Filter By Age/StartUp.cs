
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class StartUp
    {
        static void Main()
        {
            var persons = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var data = Console
                    .ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = data[0];
                var age = int.Parse(data[1]);

                var person = new Person(name, age);

                persons.Add(person);
            }

            var condition = Console.ReadLine();
            var conditionAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = condition switch
            {
                "older" => p => p.Age >= conditionAge,
                "younger" => p => p.Age < conditionAge,
                _ => p => true
            };

            var format = Console.ReadLine();

            Func<Person, string> selector = format switch
            {
                "name" => p => $"{p.Name}",
                "age" => p => $"{p.Age}",
                "name age" => p => $"{p.Name} - {p.Age}",
                _ => null
            };

            persons
                .Where(filter)
                .Select(selector)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
