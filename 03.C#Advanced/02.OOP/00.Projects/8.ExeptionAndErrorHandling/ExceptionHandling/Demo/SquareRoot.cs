using System;
using System.ComponentModel.DataAnnotations;

namespace Demo
{
    public class SquareRoot
    {
        private int number;

        public SquareRoot(int number)
        {
            this.Number = number;
        }

        public int Number 
        {
            get => this.number;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.number = value;
            }
        }

        public double CalculateSqrRoot()
        {
            return Math.Sqrt(this.Number);
        }
    }
}
