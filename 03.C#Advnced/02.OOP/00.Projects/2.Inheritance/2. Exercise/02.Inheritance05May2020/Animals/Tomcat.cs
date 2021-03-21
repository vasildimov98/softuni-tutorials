namespace Animals
{
    class Tomcat : Cat
    {
        private const string MALE_CAT = "Male";
        public Tomcat(string name, int age)
            : base(name, age, MALE_CAT)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
