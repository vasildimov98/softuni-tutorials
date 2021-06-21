using System.Text;

namespace P05.CarSalesman
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
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var weight
                = this.Weight == 0 ?
                "n/a" :
                this.Weight.ToString();

            var color
                = this.Color == null ?
                "n/a" :
                this.Color.ToString();

            sb
                .AppendLine($"{this.Model}:")
                .AppendLine(this.Engine.ToString())
                .AppendLine($"  Weight: {weight}")
                .AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();
        }
    }
}
