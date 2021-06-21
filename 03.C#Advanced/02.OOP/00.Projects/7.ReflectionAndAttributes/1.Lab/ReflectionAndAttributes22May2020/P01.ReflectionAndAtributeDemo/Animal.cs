namespace P01.ReflectionAndAtributeDemo
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, string owner)
        {
            this.Name = name;
            this.Owner = owner;
        }

        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
