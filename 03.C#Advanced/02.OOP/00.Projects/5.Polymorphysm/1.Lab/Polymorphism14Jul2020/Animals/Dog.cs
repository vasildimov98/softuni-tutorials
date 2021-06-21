namespace Animals
{
    using System;
    public class Dog : Animal
    {
        private const string SOUND = "DJAAF";

        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public override sealed string ExplainSelf()
        {
            return $"{base.ExplainSelf()}{Environment.NewLine}{SOUND}";
        }
    }
}
