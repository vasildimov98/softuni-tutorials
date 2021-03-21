namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private readonly ICollection<Car> cars;

        private int capacity;

        private Parking()
        {
            this.cars = new List<Car>();
        }
        public Parking(int capacity)
            : this()
        {
            this.capacity = capacity;
        }

        public int Count => this.Cars.Count;
        public IReadOnlyCollection<Car> Cars
            => (IReadOnlyCollection<Car>)this.cars;

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            var car = this.cars
                .FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars.Remove(car);

            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars
                .FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var rn in registrationNumbers)
            {
                var car = this.cars
                    .FirstOrDefault(c => c.RegistrationNumber == rn);

                if (car != null)
                {
                    this.cars.Remove(car);
                }
            }
        }
    }
}
