using System.Text;

namespace P08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
           : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var weight = this.Weight.HasValue ? $"{this.Weight}" : "n/a";
            var color = this.Color != null ? $"{this.Color}" : "n/a";

            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"  {this.Engine}");
            stringBuilder.AppendLine($"  Weight: {weight}");
            stringBuilder.AppendLine($"  Color: {color}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
