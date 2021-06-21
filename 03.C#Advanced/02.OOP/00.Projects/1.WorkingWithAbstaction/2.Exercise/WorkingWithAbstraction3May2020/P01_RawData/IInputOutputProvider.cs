using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public interface IInputOutputProvider
    {
        string GetInput();

        void GetOutput(string output);
    }
}
