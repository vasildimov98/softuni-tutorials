using System.Text;

namespace P08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
          : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var displacement = this.Displacement.HasValue ? $"{this.Displacement}" : "n/a";
            var efficiency = this.Efficiency != null ? $"{this.Efficiency}" : "n/a";

            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"    Power: {this.Power}");
            stringBuilder.AppendLine($"    Displacement: {displacement}");
            stringBuilder.AppendLine($"    Efficiency: {efficiency}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
