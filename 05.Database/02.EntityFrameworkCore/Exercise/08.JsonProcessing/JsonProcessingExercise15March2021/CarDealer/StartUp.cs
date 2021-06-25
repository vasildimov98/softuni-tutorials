namespace CarDealer
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using DTO.Import;
    using DTO.Export;

    public class StartUp
    {
        private static MapperConfiguration cfg;
        private static IMapper mapper;

        public static void Main()
        {
            var context = new CarDealerContext();

            // Resetting Database
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // Import Data
            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");

            //ImportSuppliers(context, suppliersJson);
            //ImportParts(context, partsJson);
            //ImportCars(context, carsJson);
            //ImportCustomers(context, customersJson);
            //var result = ImportSales(context, salesJson);

            //Console.WriteLine(result);

            // Export Data
            var directory = "../../../Results/";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //var file = directory + "ordered-customers.json";
            //var file = directory + "toyota-cars.json";
            //var file = directory + "local-suppliers.json";
            //var file = directory + "cars-and-parts.json";
            var file = directory + "sales-discounts.json";

            var contents = GetSalesWithAppliedDiscount(context);
            
            File.WriteAllText(file, contents);
        }

        // Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = GetDataToImport<SupplierImportDto, Supplier>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.Select(x => x.Id).ToHashSet();

            var parts = GetDataToImport<PartImportDto, Part>(inputJson)
                    .Where(x => supplierIds.Contains(x.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsArgs = JsonConvert.DeserializeObject<IEnumerable<CarImportDto>>(inputJson);

            var cars = new List<Car>();

            foreach (var carArgs in carsArgs)
            {
                var car = new Car
                {
                    Make = carArgs.Make,
                    Model = carArgs.Model,
                    TravelledDistance = carArgs.TravelledDistance
                };

                var carPartsIdsDistincs = carArgs.PartsId.Distinct();

                var partsCars = new List<PartCar>();
                foreach (var partId in carPartsIdsDistincs)
                {
                    var carPart = new PartCar
                    {
                        Car = car,
                        PartId = partId
                    };

                    partsCars.Add(carPart);
                }

                context.PartCars.AddRange(partsCars);

                cars.Add(car);
            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = GetDataToImport<CustomerImportDto, Customer>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = GetDataToImport<SaleImportDto, Sale>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var customerDtos = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<CustomerExportDto>(cfg)
                .AsEnumerable();

            var customerJson = JsonConvert.SerializeObject(customerDtos, Formatting.Indented);

            return customerJson;
        }

        // Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            InitializeAutoMapper();

            var carsMakeToyotaDtos = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<CarMakeToyotaExport>(cfg)
                .ToList();

            var carsJson = JsonConvert.SerializeObject(carsMakeToyotaDtos, Formatting.Indented);

            return carsJson;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .ProjectTo<SupplierExportDto>(cfg)
                .AsEnumerable();

            var localSuppliersJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return localSuppliersJson;
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InitializeAutoMapper();

            var carPartsDtos = context.Cars
                .ProjectTo<CarPartExportDto>(cfg)
                .AsEnumerable();

            var carPartsJSon = JsonConvert.SerializeObject(carPartsDtos, Formatting.Indented);

            return carPartsJSon;
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeAutoMapper();

            var customerInfoDtos = context.Customers
                .Where(x => x.Sales.Count > 0)
                .ProjectTo<CustomerInfoExport>(cfg)
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.SalesCount)
                .ToList();

            var customerInfoJson = JsonConvert.SerializeObject(customerInfoDtos, Formatting.Indented);

            return customerInfoJson;
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            InitializeAutoMapper();

            var saleDiscount = context.Sales
                .ProjectTo<SaleWithDiscountExport>(cfg)
                .Take(10)
                .AsEnumerable();

            var salesWithDiscount = JsonConvert.SerializeObject(saleDiscount, Formatting.Indented);

            return salesWithDiscount;
        }

        // Private Helper Methods
        private static IEnumerable<TModel> GetDataToImport<TDto, TModel>(string inputJson)
        {
            InitializeAutoMapper();

            var deserializeData = JsonConvert.DeserializeObject<IEnumerable<TDto>>(inputJson);

            var models = mapper.Map<IEnumerable<TModel>>(deserializeData);

            return models;
        }

        private static void InitializeAutoMapper()
        {
            cfg = new MapperConfiguration(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            mapper = cfg.CreateMapper();
        }
    }
}