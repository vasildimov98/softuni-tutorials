namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private const string KEY_SEPARATOR = "|!|";

        // TODO: define the underlying data structures here ...
        private readonly Dictionary<string, Person> peopleByEmail;
        private readonly Dictionary<string, SortedSet<Person>> peopleByEmailDomains;
        private readonly Dictionary<string, SortedSet<Person>> peopleByNamesAndTowns;
        private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAges;
        private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleInTownByAge;

        public PersonCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomains = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNamesAndTowns = new Dictionary<string, SortedSet<Person>>();
            this.peopleByAges = new OrderedDictionary<int, SortedSet<Person>>();
            this.peopleInTownByAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            var person = this.FindPerson(email);
            if (person != null)
                return false;

            person = new Person
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            };

            var emailDomain = this.ExtractEmailDomain(email);
            var nameTownKey = this.CreateKeyFromNameAndTown(name, town);
            this.peopleInTownByAge.EnsureKeyExists(town);

            this.peopleByEmail[email] = person;
            this.peopleByEmailDomains.AppendValueToKey(emailDomain, person);
            this.peopleByNamesAndTowns.AppendValueToKey(nameTownKey, person);
            this.peopleByAges.AppendValueToKey(age, person);
            this.peopleInTownByAge[town].AppendValueToKey(age, person);

            return true;
        }

        public int Count => this.peopleByEmail.Count;

        public Person FindPerson(string email)
        {
            Person foundPerson;
            this.peopleByEmail
                .TryGetValue(email, out foundPerson);

            return foundPerson;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
                return false;


            var emailDomain = this.ExtractEmailDomain(email);
            var nameTownKey = this.CreateKeyFromNameAndTown(person.Name, person.Town);
            var ageKey = person.Age;
            var townKey = person.Town;

            this.peopleByEmail.Remove(email);
            this.peopleByEmailDomains[emailDomain].Remove(person);
            this.peopleByNamesAndTowns[nameTownKey].Remove(person);
            this.peopleByAges[ageKey].Remove(person);
            this.peopleInTownByAge[townKey][ageKey].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
            => this.peopleByEmailDomains.GetValuesForKey(emailDomain);

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var nameTownKey = this.CreateKeyFromNameAndTown(name, town);
            return this.peopleByNamesAndTowns.GetValuesForKey(nameTownKey);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var peopleInRange = this.peopleByAges
                .Range(startAge, true, endAge, true);

            foreach (var peopleByAge in peopleInRange)
                foreach (var person in peopleByAge.Value)
                    yield return person;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            if (!this.peopleInTownByAge.ContainsKey(town))
                yield break;


            var peopleInRange = this.peopleInTownByAge[town]
                .Range(startAge, true, endAge, true);

            foreach (var peopleByAge in peopleInRange)
                foreach (var person in peopleByAge.Value)
                    yield return person;
        }

        private string ExtractEmailDomain(string email)
        {
            return email
                .Split('@')[1];
        }

        private string CreateKeyFromNameAndTown(string name, string town)
            => name + KEY_SEPARATOR + town;
    }
}
