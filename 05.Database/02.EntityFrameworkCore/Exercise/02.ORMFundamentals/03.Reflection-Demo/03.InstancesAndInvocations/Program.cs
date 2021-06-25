namespace InstancesAndInvocations
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Program
    {
        public static void Main()
        {
            Type personType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == "Person");

            // Create instance by calling the constructor method
            var person = new Person("Victor Krum", 22);

            Type[] constructorArgs = new[] { typeof(string), typeof(int) };
            ConstructorInfo constructor = personType?.GetConstructor(constructorArgs);
            var instanceWithCtor = constructor.Invoke(new object[] { "Victor Krum", 22 }) as IPerson;
            Console.WriteLine(instanceWithCtor);

            // Create instance with Activator.CreateInstance
            object[] myConstructorParams = { "Nikolay Kostov", 29 };
            var instance = Activator.CreateInstance(personType, myConstructorParams) as Person;
            Console.WriteLine(instance);

            // Invoke method Eat
            MethodInfo eatMethod = typeof(Person).GetMethod("Eat");
            object eatMethodResult = eatMethod.Invoke(instance, new object[] { "Burger" });
            Console.WriteLine(eatMethodResult);

            // Work with get and set
            var propertyName = personType.GetProperty("Name");
            object nameValue = propertyName.GetValue(instance);
            Console.WriteLine(nameValue);
            propertyName.SetValue(instance, "Ivaylo Kenov");
            nameValue = propertyName.GetValue(instance);
            Console.WriteLine(nameValue);
        }
    }
}
