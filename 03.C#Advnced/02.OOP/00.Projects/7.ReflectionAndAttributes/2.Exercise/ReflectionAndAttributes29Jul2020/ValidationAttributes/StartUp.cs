namespace ValidationAttributes
{
    using System;
    using Attributes;

    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
             (
                 "Pesho",
                 13
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
