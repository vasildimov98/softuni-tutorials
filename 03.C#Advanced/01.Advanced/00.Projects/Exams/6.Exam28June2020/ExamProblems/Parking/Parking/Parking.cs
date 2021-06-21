namespace Parking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;

    public class Parking
    {
        private readonly ICollection<Car> data;

        private Parking()
        {
            this.data = new List<Car>();
        }
        public Parking(string type, int capacity)
            : this()
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public int Count => this.data.Count;
        public string Type { get; private set; }
        public int Capacity { get; private set; }

        // O(1)
        public void Add(Car car)
        {
            if (this.Count + 1 <= this.Capacity)
            {
                this.data.Add(car);
            }
        }

        // O(n)
        public bool Remove(string manufacturer, string model)
        {
            var car = this.data
                .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return this.data.Remove(car);
        }

        // O(n)
        public Car GetLatestCar()
            => this.data
            .OrderByDescending(c => c.Year)
            .FirstOrDefault();

        // O(n)
        public Car GetCar(string manufacturer, string model)
         => this.data
            .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        // O(n)
        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
