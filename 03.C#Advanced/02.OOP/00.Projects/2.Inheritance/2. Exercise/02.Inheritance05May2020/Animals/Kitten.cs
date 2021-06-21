namespace Animals
{
    public class Kitten : Cat
    {
        private const string FEMALE_CAT = "Female";
        public Kitten(string name, int age)
            : base(name, age, FEMALE_CAT)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
