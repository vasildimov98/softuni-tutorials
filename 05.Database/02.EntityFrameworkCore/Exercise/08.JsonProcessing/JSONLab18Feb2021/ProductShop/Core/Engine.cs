namespace ProductShop.Core
{
    using System;
    using System.IO;
    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using ProductShop.DTO.Product;
    using Newtonsoft.Json.Serialization;
    using ProductShop.DTO.User;
    using ProductShop.DTO.Categories;
    using ProductShop.DTO.UserWithProducts;

    public class Engine
    {
        private readonly string[] DIRECTORY_PATH_PARTS = { "..", "..", "..", "Datasets", "Results" };
        private readonly IMapper mapper;

        public Engine()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        public void Run()
        {
            var context = new ProductShopContext();

            var directoryPath = Path.Combine(DIRECTORY_PATH_PARTS);

            var fileName = "users-and-products.json";

            var filePath = this.EnsureDirectoryExists(directoryPath, fileName);

            var result = this.GetUsersWithProducts(context);

            File.WriteAllText(filePath, result);
        }

        //Problem 01
        public string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            var userCountImported = context.SaveChanges();

            return $"Successfully imported {userCountImported}";
        }

        //Problem 02
        public string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            var output = context.SaveChanges();

            return $"Successfully imported {output}";
        }

        //Problem 03
        public string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                    .DeserializeObject<Category[]>(inputJson)
                    .Where(c => c.Name != null);

            context.Categories.AddRange(categories);

            var output = context.SaveChanges();

            return $"Successfully imported {output}";
        }

        //Problem 04
        public string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            var output = context.SaveChanges();

            return $"Successfully imported {output}";
        }

        //Problem 05
        public string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductDTO>(this.mapper.ConfigurationProvider)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var prductJson = JsonConvert.SerializeObject(products, settings);

            return prductJson;
        }

        //Problem 06
        public string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserDTO>(this.mapper.ConfigurationProvider)
                .ToArray();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var usersJson = JsonConvert.SerializeObject(users, settings);

            return usersJson;
        }

        //Problem 07
        public string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoryDTO>(this.mapper.ConfigurationProvider)
                .ToArray();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var categoriesJson = JsonConvert.SerializeObject(categories, settings);

            return categoriesJson;
        }

        //Problem 08
        public string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .ProjectTo<UserInfoDTO>(this.mapper.ConfigurationProvider)
                .OrderByDescending(ui => ui.SoldProducts.Count)
                .ToArray();

            var userWithProducts = new UserWithProductsDTO 
            {
                UsersCount = users.Length,
                Users = users
            };


            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var userJson = JsonConvert.SerializeObject(userWithProducts, settings);

            return userJson;
        }

        //Helpers
        private string EnsureDirectoryExists(string path, string file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePathOutput = Path.Combine(path, file);

            if (!File.Exists(filePathOutput))
            {
                File.Create(filePathOutput);
            }

            return filePathOutput;
        }
    }
}
