namespace CarManufacturer
{
    using System.Text;
    public class Car
    {
        // Constant
        private const string DEF_MAKE = "VW";
        private const string DEF_MODEL = "Golf";
        private const int DEF_YEAR = 2025;
        private const double DEF_FUEL_QUANTITY = 200;
        private const double DEF_FUEL_CONSUMPTION = 10;

        private const int KM = 100;

        // Fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        // Constructors
        public Car()
        {
            this.Make = DEF_MAKE;
            this.Model = DEF_MODEL;
            this.Year = DEF_YEAR;
            this.FuelQuantity = DEF_FUEL_QUANTITY;
            this.FuelConsumption = DEF_FUEL_CONSUMPTION;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
         : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
         : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        // Properties
        public string Make
        {
            get => this.make;
            set => this.make = value;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }
        public Tire[] Tires
        {
            get => this.tires;
            set => this.tires = value;
        }

        // Methods
        public void Drive(double distance)
        {
            var distInKm = distance / KM;

            var fuelNeeded = this.fuelConsumption * distInKm;

            if (this.FuelQuantity >= fuelNeeded)
            {
                this.fuelQuantity -= fuelNeeded;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Make: {this.Make}")
                .AppendLine($"Model: {this.Model}")
                .AppendLine($"Year: {this.Year}")
                .AppendLine($"Fuel: {this.FuelQuantity}");

            return sb.ToString().TrimEnd();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Make: {this.Make}")
                .AppendLine($"Model: {this.Model}")
                .AppendLine($"Year: {this.Year}")
                .AppendLine($"HorsePowers: {this.Engine.HorsePower}")
                .AppendLine($"FuelQuantity: {this.FuelQuantity}");

            return sb.ToString().TrimEnd();
        }
    }
}
