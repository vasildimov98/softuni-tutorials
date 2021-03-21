namespace Animals
{
    using System.Text;
    public class Cat : Animal
    {
        private const string CAT_SOUND = "MEEOW";

        public Cat(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"I am {this.Name} and my fovourite food is {this.FavouriteFood}")
                .Append(CAT_SOUND);

            return sb.ToString().TrimEnd();
        }
    }
}
