namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using ProductShop.DTO.Import;
    using AutoMapper.QueryableExtensions;
    using ProductShop.DTO.Export;
    using Newtonsoft.Json.Serialization;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        private static MapperConfiguration cfg;
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //////Resetting Db
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJson = File.ReadAllText("../../../Datasets/users.json");
            //var productsJson = File.ReadAllText("../../../Datasets/products.json");
            //var categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //var categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(context, usersJson);
            //ImportProducts(context, productsJson);
            //ImportCategories(context, categoriesJson);
            //ImportCategoryProducts(context, categoriesProductsJson);

            //var contents = GetProductsInRange(context);

            //var file = CreateFileInDirectory("../../../Result", "products-in-range.json");
            //File.WriteAllText(file, contents);

            //var contents = GetSoldProducts(context);

            //var file = CreateFileInDirectory("../../../Result", "users-sold-products.json");
            //File.WriteAllText(file, contents);

            //var file = CreateFileInDirectory("../../../Result", "categories-by-products.json");

            //var contents = GetCategoriesByProductsCount(context);

            //File.WriteAllText(file, contents);

            var contents = GetUsersWithProducts(context);

            var file = CreateFileInDirectory("../../../Result", "users-and-products.json");
            File.WriteAllText(file, contents);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = GetDataToImport<UserImportDto, User>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = GetDataToImport<ProductImportDto, Product>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = GetDataToImport<CategoryImportDto, Category>(inputJson)
                .Where(x => x.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = GetDataToImport<CategoryProductImportDto, CategoryProduct>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeAutoMapper();

            var productDtos = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductInRangeExportDto>(cfg)
                .ToList();

            var productsInRangeJson = JsonConvert.SerializeObject(productDtos, Formatting.Indented);

            return productsInRangeJson;
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeAutoMapper();

            var userWithSoldProducts = context.Users
                .Where(x => x.ProductsSold.Any(y => y.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<UserSoldProductExportDto>(cfg)
                .ToList();

            var userSoldProductJson = JsonConvert.SerializeObject(userWithSoldProducts, Formatting.Indented);

            Console.WriteLine(userSoldProductJson.Length);

            return userSoldProductJson;
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializeAutoMapper();

            var categoriesWithProductsCount = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .ProjectTo<CategoryWithProductCountExportDto>(cfg)
                .ToList();

            var categoriesWithProductsCountJson = JsonConvert.SerializeObject(categoriesWithProductsCount, Formatting.Indented);

            return categoriesWithProductsCountJson;
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializeAutoMapper();

            var users = context.Users
                .Include(x => x.ProductsSold)
                .AsEnumerable()
                .Where(x => x.ProductsSold.Any(y => y.BuyerId != null))
                .Select(x => new 
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Where(y => y.BuyerId != null).Count(),
                        Products = x.ProductsSold
                            .Where(y => y.BuyerId != null)
                            .Select(y => new
                            {
                                y.Name,
                                y.Price
                            })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();

            var userProductDto = new  
            {
                UsersCount = users.Length,
                Users = users
            };

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var usersProductsJson = JsonConvert.SerializeObject(userProductDto, settings);

            return usersProductsJson;
        }

        // Private Methods
        private static IEnumerable<TModel> GetDataToImport<TImportDto, TModel>(string inputJson)
        {
            InitializeAutoMapper();

            var productImportDtos = JsonConvert.DeserializeObject<IEnumerable<TImportDto>>(inputJson);

            var products = mapper.Map<IEnumerable<TModel>>(productImportDtos);

            return products;
        }

        private static void InitializeAutoMapper()
        {
            cfg = new MapperConfiguration(opt =>
            {
                opt.AddProfile<ProductShopProfile>();
            });

            mapper = cfg.CreateMapper();
        }

        private static string CreateFileInDirectory(string directory, string file)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(directory, file);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }
    }
}