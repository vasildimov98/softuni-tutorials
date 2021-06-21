using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private readonly HashSet<Person> members;

        public Family()
        {
            members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestFamilyMember()
        {
            return members
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }

        public HashSet<Person> GetPeopleOlderThan30()
        {
            return members
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToHashSet();
        }
    }
}
