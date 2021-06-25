namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Data;
    using Facade;
    using Models;
    using DTOs.Exports;
    using DTOs.Imports;
    using System.Linq.Expressions;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            ////Part I. Importing Data
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //var suppliersResult = ImportSuppliers(context, suppliersXml);
            //var partsResult = ImportParts(context, partsXml);
            //var carsResult = ImportCars(context, carsXml);
            //var customersResult = ImportCustomers(context, customersXml);
            //var salesResult = ImportSales(context, salesXml);

            //Console.WriteLine(suppliersResult);
            //Console.WriteLine(partsResult);
            //Console.WriteLine(carsResult);
            //Console.WriteLine(customersResult);
            //Console.WriteLine(salesResult);


            //Part II. Exporting Data
            //Directory.CreateDirectory("../../../Results");
            //var result = GetCarsWithDistance(context);
            //File.WriteAllText("../../../Results/cars.xml", result);

            //var result = GetCarsFromMakeBmw(context);
            //File.WriteAllText("../../../Results/bmw-cars.xml", result);

            //var result = GetLocalSuppliers(context);
            //File.WriteAllText("../../../Results/local-suppliers.xml", result);

            //var result = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText("../../../Results/cars-and-parts.xml", result);

            //var result = GetTotalSalesByCustomer(context);
            //File.WriteAllText("../../../Results/customers-total-sales.xml", result);

            var result = GetSalesWithAppliedDiscount(context);
            File.WriteAllText("../../../Results/sales-discounts.xml", result);
        }

        //Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersDTO = XmlConverter.DeserializeObject<ImportSupplierDTO[]>("Suppliers", inputXml);

            var suppliers = suppliersDTO
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Problem 02
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDTO = XmlConverter.DeserializeObject<ImportPartDTO[]>("Parts", inputXml);

            var suppliersIds = context.Suppliers.Select(s => s.Id).ToHashSet();

            var parts = partsDTO
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 03
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDTOs = XmlConverter.DeserializeObject<ImportCarDTO[]>("Cars", inputXml);

            var partsIds = context.Parts.Select(p => p.Id).ToHashSet();

            var cars = new List<Car>();
            foreach (var carDTO in carsDTOs)
            {
                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelDistance
                };

                var existingParts = carDTO
                    .PartsIds
                    .Where(p => partsIds.Contains(p.PartId))
                    .Select(p => p.PartId)
                    .Distinct();

                foreach (var partId in existingParts)
                {
                    var carPart = new PartCar
                    {
                        PartId = partId,
                        Car = car
                    };

                    car.PartCars.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customerDTO = XmlConverter.DeserializeObject<ImportCustomerDTO[]>("Customers", inputXml);

            var customers = customerDTO
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDTOs = XmlConverter.DeserializeObject<ImportSaleDTO[]>("Sales", inputXml);

            var carsIds = context.Cars.Select(c => c.Id).ToHashSet();

            var sales = salesDTOs
                .Where(dto => carsIds.Contains(dto.CarId))
                .Select(dto => new Sale
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Probelem 06
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            var output = XmlConverter.SerializeObject("cars", cars);

            return output;
        }

        //Problem 07
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make.ToUpper() == "BMW")
                .Select(c => new ExportBMWCarDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelDistance)
                .ToList();

            var output = XmlConverter.SerializeObject("cars", bmwCars);

            return output;
        }

        //Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSupplierDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var output = XmlConverter.SerializeObject("suppliers", suppliers);

            return output;
        }

        //Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Where(c => c.PartCars.Any())
                .Select(c => new ExportCarWithPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new PartDTO
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            var output = XmlConverter.SerializeObject("cars", carsWithParts);

            return output;
        }

        //Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithTotalSales = context.Sales
               .Select(s => new ExportCustomerWithTotalSaleDTO
               {
                   FullName = s.Customer.Name,
                   BoughtCars = s.Customer.Sales.Count,
                   SpentMoney = s.Car.PartCars.Sum(pc => pc.Part.Price)
               })
               .OrderByDescending(s => s.SpentMoney)
               .ToList();

            var output = XmlConverter.SerializeObject("customers", customersWithTotalSales);

            return output;
        }

        //Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleDTO
                {
                    Car = new CarResultModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100M
                })
                .ToList();

            var output = XmlConverter.SerializeObject("sales", sales);

            return output;
        }
    }
}