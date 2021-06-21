namespace Animals
{
    using System;

    public class Cat : Animal
    {
        private const string SOUND = "MEEOW";
        public Cat(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}{Environment.NewLine}{SOUND}";
        }
    }
}
