namespace P04.AddVAT
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const decimal VAT_MULT = 1.2m;
        public static void Main(string[] args)
        {
            Func<string, decimal> parser = decimal.Parse;
            Func<decimal, decimal> addVAT = n => n * VAT_MULT;

            Action<decimal> printInCorrectFormat = n => Console.WriteLine($"{n:F2}");

            Console
                .ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(addVAT)
                .ToList()
                .ForEach(printInCorrectFormat);
        }
    }
}
