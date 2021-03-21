namespace NeedForSpeed
{
    using NeedForSpeed.Cars;
    using NeedForSpeed.Motorcycles;
    
    public class StartUp
    {
        public static void Main()
        {
            var vehicle = new Vehicle(200, 400);
            var car = new Car(200, 400);
            var familyCar = new FamilyCar(200, 400);
            var sportCar = new SportCar(400, 500);
            var motorcycle = new Motorcycle(200, 400);
            var crossMotorCycle = new CrossMotorcycle(250, 400);
            var raceMotorCycle = new RaceMotorcycle(300, 400);
            System.Console.WriteLine(vehicle.Fuel);
            System.Console.WriteLine(car.Fuel);
            System.Console.WriteLine(familyCar.Fuel);
            System.Console.WriteLine(sportCar.Fuel);
            System.Console.WriteLine(motorcycle.Fuel);
            System.Console.WriteLine(crossMotorCycle.Fuel);
            System.Console.WriteLine(raceMotorCycle.Fuel);
            System.Console.WriteLine("=======================================================");
            System.Console.WriteLine(vehicle.FuelConsumption);
            System.Console.WriteLine(car.FuelConsumption);
            System.Console.WriteLine(sportCar.FuelConsumption);
            System.Console.WriteLine(familyCar.FuelConsumption);
            System.Console.WriteLine(motorcycle.FuelConsumption);
            System.Console.WriteLine(crossMotorCycle.FuelConsumption);
            System.Console.WriteLine(raceMotorCycle.FuelConsumption);
            System.Console.WriteLine("=======================================================");
            vehicle.Drive(100);
            car.Drive(50);
            sportCar.Drive(50);
            crossMotorCycle.Drive(50);
            raceMotorCycle.Drive(100);
            System.Console.WriteLine("=======================================================");
            System.Console.WriteLine(vehicle.Fuel);
            System.Console.WriteLine(car.Fuel);
            System.Console.WriteLine(familyCar.Fuel);
            System.Console.WriteLine(sportCar.Fuel);
            System.Console.WriteLine(motorcycle.Fuel);
            System.Console.WriteLine(crossMotorCycle.Fuel);
            System.Console.WriteLine(raceMotorCycle.Fuel);
        }
    }
}
