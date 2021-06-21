namespace P01.ReflectionAndAtributeDemo
{
    using System;
    using System.Text;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type typeOfCat1, typeOfCat2;
            DerivedClassExample(out typeOfCat1, out typeOfCat2);
            BaseclassExample(typeOfCat2);
            InterfacesExample(typeOfCat1);
            ActivatorExample();
            FieldsExample(typeOfCat1);
            FieldValueChangeExample(typeOfCat1);
        }

        private static void FieldValueChangeExample(Type typeOfCat1)
        {
            PrintBorder("Change fields Value:");
            var testIstance = Activator.CreateInstance(typeOfCat1, "Pesho", "Vasko");
            var field = typeOfCat1.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(testIstance, 1231);
            Console.WriteLine((int)field.GetValue(testIstance));
        }

        private static void FieldsExample(Type typeOfCat1)
        {
            PrintBorder("Obtain Fileds:");

            var field = typeOfCat1.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(field.Name);
            Console.WriteLine(field.FieldType);

            var fields = typeOfCat1.BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public| BindingFlags.Static);
            foreach (var currField in fields)
            {
                Console.WriteLine(currField.Name);
                Console.WriteLine(currField.FieldType);
                Console.WriteLine(currField.IsPrivate);
                Console.WriteLine(currField.IsPublic);
                Console.WriteLine(currField.IsStatic);
                Console.WriteLine(currField.IsFamily);
                Console.WriteLine(currField.IsAssembly);
            }
        }

        private static void ActivatorExample()
        {
            PrintBorder("Activator.CreateInstance:");

            var sbType = Type.GetType("System.Text.StringBuilder");
            var sbInstance = (StringBuilder)System.Activator
                .CreateInstance(sbType);

            var sbInstCapacity = (StringBuilder)System.Activator
              .CreateInstance(sbType, new object[] { 10 });

            Console.WriteLine(sbInstance.Capacity);
            Console.WriteLine(sbInstCapacity.Capacity);
        }

        private static void InterfacesExample(Type typeOfCat1)
        {
            var interfaces = typeOfCat1.GetInterfaces();

            PrintBorder("Interfaces:");
            foreach (var @interface in interfaces)
            {
                Console.WriteLine(@interface.Name);
            }
        }

        private static void BaseclassExample(Type typeOfCat2)
        {
            var baseClass = typeOfCat2.BaseType;

            PrintBorder("Base class:");

            Console.WriteLine(baseClass.Name);
            Console.WriteLine(baseClass.FullName);
        }

        private static void DerivedClassExample(out Type typeOfCat1, out Type typeOfCat2)
        {
            PrintBorder("Devide class:");
            typeOfCat1 = typeof(Cat);
            Console.WriteLine(typeOfCat1.Name);
            typeOfCat2 = Type.GetType("P01.ReflectionAndAtributeDemo.Cat");
            Console.WriteLine(typeOfCat2.FullName);
        }

        private static void PrintBorder(string name)
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"Printing resul of {name}");
        }
    }
}
