using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class ConsoleInputOutput : IInputOutputProvider
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void GetOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
