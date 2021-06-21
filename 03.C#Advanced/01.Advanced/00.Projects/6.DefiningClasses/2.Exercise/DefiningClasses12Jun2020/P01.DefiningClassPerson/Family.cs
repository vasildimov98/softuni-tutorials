namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private readonly ICollection<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public IReadOnlyCollection<Person> People
            => (IReadOnlyCollection<Person>)this.people;

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }

        public IEnumerable<Person> GetAllPeopleOlderThanThirty()
        {
            return this.People
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name);
        }
    }
}
