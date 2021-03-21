using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        private const string DOG_SOUND = "DJAAF";

        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"I am {this.Name} and my fovourite food is {this.FavouriteFood}")
                .Append(DOG_SOUND);

            return sb.ToString().TrimEnd();
        }
    }
}
