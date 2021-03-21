using System;

class FibonacciChecks
{
    

    static void Main()
    {
        long n = int.Parse(Console.ReadLine());

        long f1 = 1;
        long f2 = 1;
        long result = 1;
        for (int i = 2; i < n; i++)
        {
            result = f1 + f2;
            f1 = f2;
            f2 = result;
        }

        Console.WriteLine(result);
    }
}