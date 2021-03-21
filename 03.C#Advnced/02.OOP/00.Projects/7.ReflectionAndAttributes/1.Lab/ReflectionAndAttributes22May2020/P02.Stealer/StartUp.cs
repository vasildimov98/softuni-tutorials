//namespace Stealer
//{
using System;
public class StartUp
{
    public static void Main()
    {
        var spy = new Spy();

        //P01. Stealer
        //var result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");

        //P02. High Quality Mistakes
        //var result = spy.AnalyzeAcessModifiers(typeof(Hacker).FullName);

        //P03. Mission Private Impossible
        //var result = spy.RevealPrivateMethods(typeof(Hacker).FullName);

        //P04. Collector
        var result = spy.CollectGettersAndSetters(typeof(Hacker).FullName);

        Console.WriteLine(result);
    }
}
//}
