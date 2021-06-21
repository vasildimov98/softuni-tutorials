namespace P00.Demo
{
    using System;
    using System.Reflection;
    using Models.Animals;
   
    public class StartUp
    {
        public static void Main()
        {
            // 1. obtain metadata by the known class name - Animal;
            //Type animalType = typeof(Animal);

            //Console.WriteLine(animalType.Name);

            // 2. obtain metadata by the unknow class name - P00.Demo.Models.Animals.Animal
            //var fullName = Console.ReadLine();
            //Type animalType1 = Type.GetType(fullName);

            //Console.WriteLine(animalType1.FullName);

            // 3. obtain base class and interfaces
            //Type baseType = animalType.BaseType;
            //Type baseType1 = animalType1.BaseType;

            //Type[] interfaces = animalType1.GetInterfaces();

            // 4. creating an instances
            //var cat = Activator.CreateInstance(animalType1);

            // 5. obtain fields
            //FieldInfo fieldInfo = animalType.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
            //FieldInfo[] fieldsInfo = animalType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            //foreach (var field in fieldsInfo)
            //{
            //    Console.WriteLine(field.Name);
            //}

            //Console.WriteLine(fieldInfo.Name);

            // 6. Changing field state

            //Type catType = typeof(Cat);

            //Cat cat = (Cat)Activator.CreateInstance(catType, new object[] { "Penka", 12, 2 });

            //FieldInfo field = catType.BaseType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);

            //Console.WriteLine(field.GetValue(cat));

            //field.SetValue(cat, "PenkaAmaNeBash");

            //Console.WriteLine(field.GetValue(cat));

            // 7. Obtain Constructor

            //ConstructorInfo[] constructorsInfo = typeof(Cat).GetConstructors();

            //ParameterInfo[] parameterInfos = constructorsInfo[1].GetParameters();

            //foreach (var parameter in parameterInfos)
            //{
            //    Console.WriteLine(parameter.Name);
            //}

            //var cat = (Cat)constructorsInfo[0].Invoke(null);

            //Console.WriteLine(cat.Name);

            // 8. Obtain methods 
            //var person = new Person("Pesho", 12, 213,12);

            //var catType = typeof(Cat);
            //var personType = typeof(Person);

            //MethodInfo[] catMethodInfos = catType.GetMethods();
            //MethodInfo[] personMethodInfos = personType.GetMethods();

            //foreach (var method in catMethodInfos)
            //{
            //    Console.WriteLine(method.Name);

            //    var methodParameters = method.GetParameters();

            //    foreach (var parameter in methodParameters)
            //    {
            //        Console.WriteLine(parameter.Name);
            //    }
            //}

            //Console.WriteLine();

            //foreach (var method in personMethodInfos)
            //{
            //    Console.WriteLine(method.Name);

            //    var methodParameters = method.GetParameters();

            //    foreach (var parameter in methodParameters)
            //    {
            //        Console.WriteLine(parameter.Name);
            //    }

            //    if (method.Name == "AddAnimal")
            //    {
            //        method.Invoke(person, new object[] { new Cat() });

            //        Console.WriteLine(person.Animals.Count);
            //    }
            //}

        }
    }
}
