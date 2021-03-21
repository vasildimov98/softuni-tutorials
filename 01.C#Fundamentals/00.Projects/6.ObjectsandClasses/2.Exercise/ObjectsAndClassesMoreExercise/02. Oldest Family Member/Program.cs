using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var families = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person(name, age);
                families.AddMember(person);
            }

            if (families.Memebers.Count > 0)
            {
                var oldestPerson = families.GetOldestMember();

                Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public Family()
        {
            Memebers = new List<Person>();
        }

        public List<Person> Memebers { get; set; }

        public void AddMember(Person member)
        {
            Memebers.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestMember = Memebers.OrderByDescending(a => a.Age).FirstOrDefault();

            return oldestMember;
        }
    }
}
