namespace P00.FunctionalProgrammingDemo
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private delegate void Calculator(int a, int b);
        public static void Main()
        {
            
        }

        private static void PassingFuncToMethodDemo()
        {
            var num = 7;

            Func<int, int> sum = num => num + 5;
            Func<int, int> mult = num => num * 5;
            Func<int, int> subtract = num => num - 5;

            var a = FancyCalculator(num, mult);
            var b = FancyCalculator(num, sum);
            var c = FancyCalculator(num, subtract);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        private static int FancyCalculator(int number, Func<int, int> calc)
        {
            return calc(number);
        }

        private static void PredicateDemo()
        {
            Predicate<string> predicate1 = str => char.IsUpper(str[0]);
            Func<string, bool> predicate2 = str => char.IsUpper(str[0]);
        }

        private static void ActionDemo()
        {
            Action<string> print = Console.WriteLine;

            print("Pesho");
            print(12.ToString());
        }

        private static void FuncGenericdemo()
        {
            Func<int, string> toString = a => a.ToString();

            var num = 12;

            var newNum = toString(num);
        }

        private static void DelegatesExample()
        {
            Calculator sum = (a, b) => Console.WriteLine(a + b);
            Calculator mult = (a, b) => Console.WriteLine(a * b);
            Calculator subtract = (a, b) => Console.WriteLine(a - b);

            CallBackMethod(sum);
            CallBackMethod(mult);
            CallBackMethod(subtract);

            Calculator calc = sum + mult + subtract;

            calc -= mult;
            calc -= sum;

            CallBackMethod(calc);
        }

        private static void CallBackMethod(Calculator calc)
        {
            calc(5, 7);
        }

        private static void LambdaExpressionsDemo()
        {
            // A. Implicit lambda expression

            // First example:
            Action<string> printer1 = msg => Console.WriteLine(msg);

            // Second example:
            Action<string> printer2 = Console.WriteLine;

            // B. Explicit lambda expression
            Func<string, int> parser = (string str) => int.Parse(str);

            // C. Zero Parameters
            Func<string> reader = () => Console.ReadLine();

            // D. More Parameters
            Func<string, int, int> someMethod = (string str, int num) => int.Parse(str) + num;

            var numbers = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(parser);

            printer1("Gosho is super cool!");
        }
    }
}
