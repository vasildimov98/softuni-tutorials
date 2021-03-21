//namespace P03.Attribute
//{

using System;
using System.Linq;
using System.Reflection;
public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);

        var methods = classType.GetMethods(BindingFlags.Instance 
            | BindingFlags.Public 
            | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute atr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written {atr.Name}");
                }
            }
        }
    }
}
//}
