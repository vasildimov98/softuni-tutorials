namespace BorderControl
{
    public class Rebel : IPerson
    {
        private const int FOOD_INCREASE = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += FOOD_INCREASE;
        }
    }
}
