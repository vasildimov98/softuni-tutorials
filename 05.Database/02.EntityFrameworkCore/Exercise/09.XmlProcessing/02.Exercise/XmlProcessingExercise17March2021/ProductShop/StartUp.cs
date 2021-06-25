namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using AutoMapper;

    using Data;
    using Dtos.Import;
    using ProductShop.Models;
    using ProductShop.XmlHelper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Dtos.Export;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        private static MapperConfiguration cfg;
        private static IMapper mapper;

        public static void Main()
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            ////Data
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //ImportCategoryProducts(context, categoriesProductsXml);

            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializerAutoMapper();

            var userImportDtos = XmlConverter.DeserializeObject<UserImportDto[]>("Users", inputXml);

            var users = mapper.Map<IEnumerable<User>>(userImportDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializerAutoMapper();

            var productImportDtos = XmlConverter.DeserializeObject<ProductImportDto[]>("Products", inputXml);

            var products = mapper.Map<Product[]>(productImportDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}"; 
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializerAutoMapper();

            var categoriesDto = XmlConverter.DeserializeObject<CategoryImportDto[]>("Categories", inputXml);

            var categories = mapper
                .Map<Category[]>(categoriesDto)
                .Where(x => x.Name != null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializerAutoMapper();

            var categoriesIds = context.Categories
                .Select(x => x.Id)
                .ToHashSet();

            var productsIds = context.Products
                .Select(x => x.Id)
                .ToHashSet();

            var categoryProductImportDtos = XmlConverter.DeserializeObject<CategoryProductImportDto[]>("CategoryProducts", inputXml);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductImportDtos)
                .Where(x => categoriesIds.Contains(x.CategoryId)
                && productsIds.Contains(x.ProductId));

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializerAutoMapper();

            var productInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductInRangeExportDto>(cfg)
                .Take(10)
                .ToArray();

            var output = XmlConverter.SerializeObject("Products", productInRange);

            return output;
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializerAutoMapper();

            var userWithSoldItem = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<UserSoldProductExportDto>(cfg)
                .Take(5)
                .ToArray();

            var output = XmlConverter.SerializeObject("Users", userWithSoldItem);

            return output;
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializerAutoMapper();

            var categoryProductsExportDtos = context.Categories
                .ProjectTo<CategoryProductsExportDto>(cfg)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var output = XmlConverter.SerializeObject("Categories", categoryProductsExportDtos);

            return output;
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .AsEnumerable()
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new UserProductExportDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProducts
                    {
                        ProductsSoldCount = x.ProductsSold.Count,
                        Products = x.ProductsSold
                            .Select(y => new ProductExport
                            {
                                Name = y.Name,
                                Price = y.Price
                            })
                            .OrderByDescending(y => y.Price)
                            .ToArray()
                    }
                })
                .ToArray();

            var usersInfo = new UsersInfoExportDto
            {
                Count = users.Count(),
                Users = users.Take(10).ToArray()
            };

            var output = XmlConverter.SerializeObject("Users", usersInfo);

            return output;
        }

        // Private Help Method
        private static void InitializerAutoMapper()
        {
            cfg = new MapperConfiguration(con =>
            {
                con.AddProfile<ProductShopProfile>();
            });

            mapper = cfg.CreateMapper();
        }
    }
}