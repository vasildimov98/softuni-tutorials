namespace ProductShop
{
    using System.IO;
    using System.Linq;

    using Data;
    using Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using ProductShop.XmlHelper;

    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new ProductShopContext())
            {
                //Part I. Import Data
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();

                //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
                //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
                //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
                //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

                //var usersCount = ImportUsers(dbContext, usersXml);
                //var productsCount = ImportProducts(dbContext, productsXml);
                //var categoriesCount = ImportCategories(dbContext, categoriesXml);
                //var categoryProductsCount = ImportCategoryProducts(dbContext, categoriesProductsXml);

                //Console.WriteLine(usersCount);
                //Console.WriteLine(productsCount);
                //Console.WriteLine(categoriesCount);
                //Console.WriteLine(categoryProductsCount);

                //Part II. Export Data
                //Directory.CreateDirectory("../../../Results");
                //var productsInRange = GetProductsInRange(dbContext);
                //File.WriteAllText("../../../Results/products-in-range.xml", productsInRange);

                //var soldProducts = GetSoldProducts(dbContext);
                //File.WriteAllText("../../../Results/users-sold-products.xml", soldProducts);

                //var categoriesByProducts = GetCategoriesByProductsCount(dbContext);
                //File.WriteAllText("../../../Results/categories-by-products.xml", categoriesByProducts);

                var userWithProducts = GetUsersWithProducts(dbContext);
                File.WriteAllText("../../../Results/users-and-products.xml", userWithProducts);
            }
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = XmlConverter.DesirializeObject<ImportUserDTO[]>("Users", inputXml);

            var users = usersDto
                .Select(dto => new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDTO = XmlConverter.DesirializeObject<ImportProductDTO[]>("Products", inputXml);

            var products = productsDTO
                .Select(dto => new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDTO = XmlConverter.DesirializeObject<ImportCategoryDTO[]>("Categories", inputXml);

            var categories = categoriesDTO
                .Where(dto => dto.Name != null)
                .Select(dto => new Category
                {
                    Name = dto.Name
                })
                .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}"; ;
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductsDTO = XmlConverter.DesirializeObject<ImportCategoryProductDTO[]>("CategoryProducts", inputXml);

            var categories = context.Categories.Select(c => c.Id).ToHashSet();
            var products = context.Products.Select(p => p.Id).ToHashSet();

            var categoryProducts = categoryProductsDTO
                .Where(dto => categories.Contains(dto.CategoryId) && products.Contains(dto.ProductId))
                .Select(dto => new CategoryProduct
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId,
                })
                .ToList();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsDTO = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var productsXml = XmlConverter.SerializeObject("Products", productsDTO);

            return productsXml;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellersDTO = context.Users
                .Where(u => u.ProductsSold.Count != 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportSellerDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                    .Select(ps => new SoldProductDTO
                                    {
                                        Name = ps.Name,
                                        Price = ps.Price
                                    }).ToArray()
                })
                .Take(5)
                .ToList();

            var output = XmlConverter.SerializeObject("Users", sellersDTO);

            return output;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesDTO = context.Categories
                .Select(c => new ExportCategoryDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Sum(sp => sp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(sp => sp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ToList();

            var output = XmlConverter.SerializeObject("Categories", categoriesDTO);

            return output;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userDTO = context.Users
                .Where(u => u.ProductsSold.Count != 0)
                .Select(u => new UserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                                    .Select(ps => new ProductDTO
                                    {
                                        Name = ps.Name,
                                        Price = ps.Price
                                    })
                                    .OrderByDescending(ps => ps.Price)
                                    .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var userWithProductsDTO = new ExportUserDTO
            {
                UsersCount = context.Users.Count(u => u.ProductsSold.Count != 0),
                Users = userDTO
            };

            var output = XmlConverter.SerializeObject("Users", userWithProductsDTO);

            return output;
        }
    }
}