namespace PersonsInfo
{
    using System.Collections.Generic;
    public class Team
    {
        private const int FORTY_YEARS_OLD_AGE = 40;

        private readonly string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        private Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public Team(string name)
            : this()
        {
            this.name = name;
        }

        public IReadOnlyCollection<Person> FirstTeam
            => this.firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam
            => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < FORTY_YEARS_OLD_AGE)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
