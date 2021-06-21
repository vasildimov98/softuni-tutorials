using System;

namespace P03.StudentSystem
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void ShowOutput(string text)
        {
            Console.WriteLine(text);
        }
    }
}
