namespace Animals
{
    public class Puppy : Dog
    {
        public Puppy(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public new string ExplainSelf()
        {
            return "I am a cute puppy";
        }
    }
}
