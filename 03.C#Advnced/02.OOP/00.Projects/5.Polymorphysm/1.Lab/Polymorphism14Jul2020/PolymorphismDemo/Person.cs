namespace PolymorphismDemo
{
    using System;
    public class Person : Mammal
    {
        public Person(string name)
            : base(name)
        {

        }

        public override string Breathe()
        {
            return "I am breathing!";
        }
        public string Speak(string word)
        {
            return $"I am saying {word}";
        }
    }
}
