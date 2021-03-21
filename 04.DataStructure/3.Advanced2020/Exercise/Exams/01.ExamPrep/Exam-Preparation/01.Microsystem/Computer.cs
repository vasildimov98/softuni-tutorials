namespace _01.Microsystem
{
    using System;

    public class Computer : IComparable<Computer>
    {
        const int INIT_RAM = 8;

        public Computer(int number, Brand brand, double price, double screenSize, string color)
        {
            this.Number = number;
            this.Brand = brand;
            this.Price = price;
            this.ScreenSize = screenSize;
            this.Color = color;

            this.RAM = INIT_RAM;
        }
        public int Number { get; set; }

        public int RAM { get; set; }

        public Brand Brand { get; set; }

        public double Price { get; set; }

        public double ScreenSize { get; set; }

        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            var computer = obj as Computer;

            return this.Number == computer.Number;
        }

        public int CompareTo(Computer otherComputer)
            => otherComputer.Number.CompareTo(this.Number);
    }
}
