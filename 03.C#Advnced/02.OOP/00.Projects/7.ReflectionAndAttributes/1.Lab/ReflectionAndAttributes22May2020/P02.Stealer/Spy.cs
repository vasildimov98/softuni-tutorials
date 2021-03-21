//namespace Stealer
//{
using System;
using System.Text;
using System.Linq;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] namesOfField)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(nameOfClass);
        var fields = type.GetFields(
            BindingFlags.Public
            | BindingFlags.NonPublic
            | BindingFlags.Instance
            | BindingFlags.Static)
            .Where(fl => namesOfField.Contains(fl.Name));

        var instance = Activator.CreateInstance(type, new object[0]);

        sb.AppendLine($"Class under investigation: {type}");
        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }
        return sb.ToString().TrimEnd();
    }
    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var typeClass = Type.GetType(className);
        var classField = typeClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        var publicMethods = typeClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        var nonPublicMethods = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in classField)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var privateMethod in nonPublicMethods.Where(get => get.Name.StartsWith("get")))
        {
            sb.AppendLine($"{privateMethod.Name} have to be public!");
        }
        foreach (var publicMethod in publicMethods.Where(set => set.Name.StartsWith("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);
        var privateMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {classType}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethod)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().TrimEnd();
    }
    public string CollectGettersAndSetters(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);

        var methods = classType.GetMethods(BindingFlags.Instance 
            | BindingFlags.Static 
            | BindingFlags.Public 
            | BindingFlags.NonPublic);

        foreach (var getter in methods.Where(mth => mth.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (var setter in methods.Where(mth => mth.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}
//}
