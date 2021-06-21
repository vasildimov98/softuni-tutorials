namespace P01_RawData
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var inputOutputProvider = new ConsoleInputOutput();
            var engine = new ProgramEngine(inputOutputProvider);

            engine.Process(lines);
        }
    }
}
