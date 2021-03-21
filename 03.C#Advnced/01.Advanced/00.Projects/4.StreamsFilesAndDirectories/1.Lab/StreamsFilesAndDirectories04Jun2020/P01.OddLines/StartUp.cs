namespace P01.OddLines
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var sourceFile = "Input.txt";

            using var streamReader = new StreamReader(sourceFile);

            var currLineCount = 0;

            using var streamWriter = new StreamWriter("Output.txt");

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();

                if (currLineCount % 2 == 1)
                {
                    streamWriter.WriteLine(line);
                }

                currLineCount++;
            }
        }
    }
}
