namespace P03.WildFarm.Factories
{
    using System;

    using P03.WildFarm.Contract;
    using P03.WildFarm.Modules.Animal;
    public static class AnimalFactory
    {
        public static IAnimal CreateFelines(string type,
            string name,
            double weight,
            string livingRegion,
            string breed)
        {
            if (type == "Cat")
            {
                return new Cat(name, weight, 0, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                return new Tiger(name, weight, 0, livingRegion, breed);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static IAnimal CreateBirds(string type,
           string name,
           double weight,
           double wingSize)
        {
            if (type == "Owl")
            {
                return new Owl(name, weight, 0, wingSize);
            }
            else if (type == "Hen")
            {
                return new Hen(name, weight, 0, wingSize);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static IAnimal CreateMammals(string type,
         string name,
         double weight,
         string livingRegion)
        {
            if (type == "Dog")
            {
                return new Dog(name, weight, 0, livingRegion);
            }
            else if (type == "Mouse")
            {
                return new Mouse(name, weight, 0, livingRegion);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
