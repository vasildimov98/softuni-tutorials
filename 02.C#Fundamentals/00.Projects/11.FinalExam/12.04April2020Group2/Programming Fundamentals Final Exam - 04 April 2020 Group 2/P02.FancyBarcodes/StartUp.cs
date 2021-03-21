namespace P02.FancyBarcodes
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            ExtractTheValidBarcode();
        }

        private static void ExtractTheValidBarcode()
        {
            var pattern = @"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            var regex = new Regex(pattern);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var barcodeArg = Console.ReadLine();

                var match = regex.Match(barcodeArg);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    FindTheBarcodeGroup(match);
                }
            }
        }

        private static void FindTheBarcodeGroup(Match match)
        {
            var barcode = match.Groups[1].Value;

            var digitMatches = Regex.Matches(barcode, $"[0-9]+");

            if (digitMatches.Count == 0)
            {
                Console.WriteLine("Product group: 00");
            }
            else
            {
                var sb = new StringBuilder();

                foreach (var digitMatch in digitMatches)
                {
                    sb.Append(digitMatch);
                }

                Console.WriteLine($"Product group: {sb}");
            }
        }
    }
}
