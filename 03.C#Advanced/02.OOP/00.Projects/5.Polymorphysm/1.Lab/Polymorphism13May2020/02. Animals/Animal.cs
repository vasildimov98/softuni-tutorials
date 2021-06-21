namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name { get; private set; }

        public string FavouriteFood { get; private set; }

        public abstract string ExplainSelf();
    }
}
