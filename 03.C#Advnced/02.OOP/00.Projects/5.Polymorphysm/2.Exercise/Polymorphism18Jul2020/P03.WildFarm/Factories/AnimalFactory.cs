namespace P03.WildFarm.Factories
{
    using System;

    using Animals;
    using Contracts;

    public static class AnimalFactory
    {
        public static IAnimal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            if (type == "Dog")
            {
                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Mouse")
            {
                return new Mouse(name, weight, livingRegion);
            }
            else
            {
                throw new ArgumentException("Invalid animal type!");
            }
        }

        public static IAnimal CreateFelines(string type, string name, double weight, string livingRegion, string breed)
        {
            if (type == "Cat")
            {
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                return new Tiger(name, weight, livingRegion, breed);
            }
            else
            {
                throw new ArgumentException("Invalid animal type!");
            }
        }

        public static IAnimal CreateBirds(string type, string name, double weight, double wingSize)
        {
            if (type == "Owl")
            {
                return new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                return new Hen(name, weight, wingSize);
            }
            else
            {
                throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
