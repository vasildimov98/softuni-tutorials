namespace ProductShop
{
    using AutoMapper;

    using Models;
    using DTO.Import;
    using ProductShop.DTO.Export;
    using System.Linq;
    using ProductShop.Data;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // ImoportDto
            this.CreateMap<UserImportDto, User>();

            this.CreateMap<ProductImportDto, Product>();

            this.CreateMap<CategoryImportDto, Category>();

            this.CreateMap<CategoryProductImportDto, CategoryProduct>();

            // ExportDto 
            this.CreateMap<Product, ProductInRangeExportDto>()
                .ForMember(x => x.Seller, opt => 
                    opt.MapFrom(y => $"{y.Seller.FirstName} {y.Seller.LastName}"));

            this.CreateMap<User, UserSoldProductExportDto>()
               .ForMember(x => x.SoldProducts, opt =>
                   opt.MapFrom(y => y.ProductsSold));

            this.CreateMap<Category, CategoryWithProductCountExportDto>()
                .ForMember(x => x.ProductsCount, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Average(z => z.Product.Price).ToString("F2")))
                .ForMember(x => x.TotalRevenue, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Sum(z => z.Product.Price).ToString("F2")));

            this.CreateMap<User, UserExportDto>()
                .ForMember(x => x.SoldProducts, opt =>
                    opt.MapFrom(y => new SoldProductExportDto
                    {
                        ProductsSoldCount = y.ProductsSold.Count,
                        Products = y.ProductsSold
                            .Select(z => new ProductExportDto
                            {
                                Name = z.Name,
                                Price = z.Price
                            }).ToArray()
                    }));
        }
    }
}
