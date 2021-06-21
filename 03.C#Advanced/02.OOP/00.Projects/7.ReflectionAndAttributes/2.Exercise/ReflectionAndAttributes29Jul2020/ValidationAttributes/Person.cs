namespace ValidationAttributes
{
    using Attributes;

    public class Person
    {
        public Person(string firstName, int age)
        {
            this.FirstName = firstName;
            this.Age = age;
        }

        [MyRequired]
        public string FirstName { get; }
        [MyRange(12, 90)]
        public int Age { get; }
    }
}
