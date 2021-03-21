namespace P06._Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private int travelDistance;
        public Car(string model,
            double fuelAmount,
            double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKilometer
        {
            get
            {
                return this.fuelConsumptionPerKilometer;
            }
            set
            {
                this.fuelConsumptionPerKilometer = value;
            }
        }

        public int TravelledDistance
        {
            get
            {
                return this.travelDistance;
            }
            set
            {
                this.travelDistance = value;
            }
        }

        public bool CanTravel(Car car, int amountOfKM)
        {
            var neededFuel = this.FuelConsumptionPerKilometer * amountOfKM;

            if (neededFuel <= this.FuelAmount)
            {
                this.FuelAmount -= neededFuel;
                this.TravelledDistance += amountOfKM;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
