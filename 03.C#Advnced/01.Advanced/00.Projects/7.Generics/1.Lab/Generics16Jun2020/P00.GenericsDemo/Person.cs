namespace P00.GenericsDemo
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return this.Name.Equals(person.Name);
        }
    }
}
