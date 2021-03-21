using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Person> persons = new List<Person>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split();

                string name = data[0];
                string iD = data[1];
                int age = int.Parse(data[2]);

                Person person = new Person(name, iD, age);

               persons.Add(person);
            }

            List<Person> orderPersons = persons
               .OrderBy(a => a.Age)
               .ToList();

            foreach (var person in orderPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
