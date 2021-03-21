namespace Collection_of_Persons
{
    using System.Linq;
    using System.Collections.Generic;

    public class PersonCollectionSlow : IPersonCollection
    {
        private readonly List<Person> people;

        public PersonCollectionSlow()
        {
            this.people = new List<Person>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.SearchForSameEmail(email))
                return false;

            var person = new Person
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            };

            this.people.Add(person);

            return true;
        }

        public int Count => this.people.Count;

        public Person FindPerson(string email)
            => this.people
            .Find(p => p.Email == email);

        public bool DeletePerson(string email)
            => this.people
            .RemoveAll(p => p.Email == email) != 0;

        public IEnumerable<Person> FindPersons(string emailDomain)
            => this.people
            .FindAll(p => p.Email.EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPersons(string name, string town)
            => this.people
            .FindAll(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
            => this.people
            .FindAll(p => startAge <= p.Age && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        => this.people
            .FindAll(p => p.Town == town && startAge <= p.Age && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        private bool SearchForSameEmail(string email)
            => this.people
            .Find(p => p.Email == email) != null;
    }
}
