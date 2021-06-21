namespace BorderControl
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private const int FOOD_INCREASE = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += FOOD_INCREASE;
        }

        public override string ToString()
        {
            return this.Birthdate;
        }
    }
}
