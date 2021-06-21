using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this (model, engine)
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
        public string Model { get; }
        public Engine Engine { get; }
        public int Weight { get; }
        public string Color { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var weight = this.Weight == -1 ? "n/a" : this.Weight.ToString();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.ToString()}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }

}
