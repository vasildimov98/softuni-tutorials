namespace CarDealer
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using AutoMapper;

    using Data;
    using Models;
    using System.Linq;
    using CarDealer.DTO.Cars;
    using System.Globalization;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private readonly static string[] RESULT_DIRECTORY_PATH_PARTS = { "..", "..", "..", "Datasets", "Results" };
        public static void Main()
        {
            InitializeMapper();
            //var inputJson = ReadInputJson();
            var filePath = CreateFilePath();
            var context = new CarDealerContext();

            var result = GetSalesWithAppliedDiscount(context);

            File.WriteAllText(filePath, result);
        }

        //Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var allParts = JsonConvert
                .DeserializeObject<List<Part>>(inputJson);

            var suppliers = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var partsWithSuplier = allParts
                .Where(p => suppliers.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(partsWithSuplier);
            var output = context.SaveChanges();

            return $"Successfully imported {output}.";
        }

        //Problem 03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsToImport = JsonConvert.DeserializeObject<List<CarImportDTO>>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carToImport in carsToImport)
            {
                var car = new Car()
                {
                    Make = carToImport.Make,
                    Model = carToImport.Model,
                    TravelledDistance = carToImport.TravelledDistance
                };

                foreach (var partId in carToImport.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count}.";
        }

        //Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Problem 05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("d", new CultureInfo("en-Us")),
                    c.IsYoungDriver
                })
                .ToList();

            var jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonCustomers;
        }

        //Problem 07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var toyotaCarsJson = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return toyotaCarsJson;
        }

        //Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }

        //Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    Car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    Parts = c.PartCars
                             .Select(pc => new
                             {
                                 pc.Part.Name,
                                 pc.Part.Price
                             })
                });

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var carsJson = JsonConvert.SerializeObject(cars, settings);

            return carsJson;
        }

        //Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Name != null && c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                }).OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var customersJson = JsonConvert.SerializeObject(customers, settings);

            return customersJson;
        }

        //Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance,
                    },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToList();

            var salesJSON = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJSON;
        }

        // Help methods
        private static string CreateFilePath()
        {
            var directoryPath = Path.Combine(RESULT_DIRECTORY_PATH_PARTS);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = "sales-discounts.json";
            var filePath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }

        private static string ReadInputJson()
        {
            var fileName = "sales.json";
            var path = Path.Combine("..", "..", "..", "Datasets", fileName);
            var inputJson = File.ReadAllText(path);
            return inputJson;
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }
    }
}