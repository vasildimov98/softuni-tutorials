namespace P02.LineNumbers
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var sourceFileName = "Input.txt";

            using var streamReader = new StreamReader(sourceFileName);

            var count = 1;

            using var streamWrite = new StreamWriter("Output.txt");

            do
            {
                var line = streamReader.ReadLine();

                streamWrite.WriteLine($"{count++}. {line}");

            } while (!streamReader.EndOfStream);
        }
    }
}
