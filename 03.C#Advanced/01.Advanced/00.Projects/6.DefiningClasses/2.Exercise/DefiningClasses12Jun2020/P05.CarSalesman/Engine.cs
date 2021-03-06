using System.Text;

namespace P05.CarSalesman
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
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var displacement
                = this.Displacement == 0 ?
                "n/a" :
                this.Displacement.ToString();

            var efficiency
                = this.Efficiency == null ?
                "n/a" :
                this.Efficiency.ToString();

            sb
                .AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacement}")
                .AppendLine($"    Efficiency: {efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
