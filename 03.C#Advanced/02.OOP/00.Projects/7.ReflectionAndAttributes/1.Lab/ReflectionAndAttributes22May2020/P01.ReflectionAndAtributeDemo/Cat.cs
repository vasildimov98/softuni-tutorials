namespace P01.ReflectionAndAtributeDemo
{
    public class Cat : Animal, IMovable
    {
        private string food = "fish";
        private int age = 12;
        public Cat(string name, string owner)
            : base(name, owner)
        {

        }

        public string Move()
        {
            return "I moved";
        }
    }
}
