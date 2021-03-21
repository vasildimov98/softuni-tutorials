namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProgramEngine
    {
        private readonly List<Car> cars;
        private IInputOutputProvider inputOutputProvider;
        public ProgramEngine(IInputOutputProvider inputOutputProvider)
        {
            this.cars = new List<Car>();
            this.inputOutputProvider = inputOutputProvider;
        }

        public void Process(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                this.GetCollectionOfCars();
            }

            this.PrintResult();
        }

        private void PrintResult()
        {
            string command = inputOutputProvider.GetInput();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));

            }
        }

        private void GetCollectionOfCars()
        {

            string[] parameters = inputOutputProvider
                .GetInput()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            var engine = this.CreateEngine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            var cargo = this.CreateCargo(cargoWeight, cargoType);

            var tires = new List<Tire>();
            this.GetCollectionOfTires(parameters, tires);

            var car = this.CreateCar(model, engine, cargo, tires);

            cars.Add(car);
        }

        private void GetCollectionOfTires(string[] parameters, List<Tire> tires)
        {
            for (int index = 5; index < 13; index += 2)
            {
                double currTirePressure = double.Parse(parameters[index]);
                int currTireAge = int.Parse(parameters[index + 1]);

                var tire = this.CreateTire(currTirePressure, currTireAge);

                tires.Add(tire);
            }
        }

        private Car CreateCar(string model,
            Engine engine,
            Cargo cargo,
            List<Tire> tires)
        {
            return new Car(model, engine, cargo, tires);
        }
        private Engine CreateEngine(int speed, int power)
        {
            return new Engine(speed, power);
        }

        private Cargo CreateCargo(int weight, string type)
        {
            return new Cargo(weight, type);
        }

        private Tire CreateTire(double pressure, int age)
        {
            return new Tire(pressure, age);
        }
    }
}

