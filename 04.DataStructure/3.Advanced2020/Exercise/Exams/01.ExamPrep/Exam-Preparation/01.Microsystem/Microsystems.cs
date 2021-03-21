namespace _01.Microsystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Microsystems : IMicrosystem
    {
        private readonly Dictionary<int, Computer> computerByNumber;
        private readonly Dictionary<Brand, SortedSet<Computer>> computersByBrand;
        private readonly Dictionary<double, SortedSet<Computer>> computerByScreenSize;
        private readonly Dictionary<string, SortedSet<Computer>> computerByColor;
        private readonly SortedSet<Computer> computers;

        public Microsystems()
        {
            this.computerByNumber = new Dictionary<int, Computer>();
            this.computersByBrand = new Dictionary<Brand, SortedSet<Computer>>();
            this.computerByScreenSize = new Dictionary<double, SortedSet<Computer>>();
            this.computerByColor = new Dictionary<string, SortedSet<Computer>>();
            this.computers = new SortedSet<Computer>();
        }

        public void CreateComputer(Computer computer)
        {
            var number = computer.Number;
            if (this.computerByNumber.ContainsKey(number))
                throw new ArgumentException();

            var brand = computer.Brand;
            var screenSize = computer.ScreenSize;
            var color = computer.Color;

            this.computerByNumber[number] = computer;
            this.computersByBrand.AppendValueToKey(brand, computer);
            this.computerByScreenSize.AppendValueToKey(screenSize, computer);
            this.computerByColor.AppendValueToKey(color, computer);
            this.computers.Add(computer);
        }

        public bool Contains(int number)
            => this.computerByNumber.ContainsKey(number);

        public int Count()
            => this.computerByNumber.Count;

        public Computer GetComputer(int number)
        {
            this.ValidateComputer(this.computerByNumber, number);

            return this.computerByNumber[number];
        }

        public void Remove(int number)
        {
            var computer = this.GetComputer(number);

            var brand = computer.Brand;
            var screenSize = computer.ScreenSize;
            var color = computer.Color;

            this.computerByNumber.Remove(number);
            this.computersByBrand[brand].Remove(computer);
            this.computerByScreenSize[screenSize].Remove(computer);
            this.computerByColor[color].Remove(computer);
            this.computers.Remove(computer);
        }

        public void RemoveWithBrand(Brand brand)
        {
            this.ValidateComputer(this.computersByBrand, brand);

            var computesByBrand = this.computersByBrand[brand].ToList();

            foreach (var computer in computesByBrand)
            {
                this.Remove(computer.Number);
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            var computer = this.GetComputer(number);

            computer.RAM = computer.RAM < ram ? ram : computer.RAM;
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
            => this.computersByBrand
            .GetValuesToKey(brand)
            .OrderByDescending(c => c.Price);

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
            => this.computerByScreenSize
            .GetValuesToKey(screenSize);

        public IEnumerable<Computer> GetAllWithColor(string color)
            => this.computerByColor
            .GetValuesToKey(color)
            .OrderByDescending(c => c.Price);

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return this.computers
                .Where(c => minPrice <= c.Price && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price);
        }

        private void ValidateComputer<TKey, TValue>(IDictionary<TKey, TValue> collection, TKey key)
        {
            if (!collection.ContainsKey(key))
                throw new ArgumentException();
        }
    }
}
