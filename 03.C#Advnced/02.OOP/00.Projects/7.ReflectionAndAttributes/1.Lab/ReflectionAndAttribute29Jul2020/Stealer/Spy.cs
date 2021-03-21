namespace Stealer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Linq.Expressions;

    public class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] filedsName)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            var classType = Type.GetType(nameOfTheClass);

            var fieldsInfo = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            var instantiatedClass = Activator.CreateInstance(classType);

            foreach (var field in fieldsInfo.Where(f => filedsName.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instantiatedClass)}");
            }

            return sb.ToString().TrimEnd();
        }
        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();

            var classType = Type.GetType(className);

            var fields = classType.GetFields();
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in methods.Where(f => f.Name.Contains("get") && f.IsPrivate))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in methods.Where(f => f.Name.Contains("set") && f.IsPublic))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();


            var classType = Type.GetType(className);

            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in classMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            var classType = Type.GetType(className);

            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var getter in methods.Where(m => m.Name.Contains("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in methods.Where(m => m.Name.Contains("set")))
            {
                sb.AppendLine($"{setter.Name} will return {setter.ReturnType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
