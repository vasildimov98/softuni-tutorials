namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string Id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = Id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}
