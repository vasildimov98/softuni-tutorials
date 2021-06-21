namespace IteratorsDemo
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {

            var library1 = new Library("Harry Potter", "Hannibal", "Angels & Demos");
            var library2 = new Library("C# for Dummies", "Java for Dummies", "Python for Dummies");

            foreach (var book in library1) 
            {
                System.Console.WriteLine(book);
            }

            System.Console.WriteLine(new string('=', 20));
            var enumerator = library2.GetEnumerator();
            while (enumerator.MoveNext())
            {
                System.Console.WriteLine(enumerator.Current);
            }
        }
    }
}
