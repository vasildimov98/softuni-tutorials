namespace ProductShop
{
    using System.Linq;

    using AutoMapper;

    using Models;
    using Dtos.Import;
    using Dtos.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Imports
            this.CreateMap<UserImportDto, User>();

            this.CreateMap<ProductImportDto, Product>();

            this.CreateMap<CategoryImportDto, Category>();

            this.CreateMap<CategoryProductImportDto, CategoryProduct>();

            // Exports
            this.CreateMap<Product, ProductInRangeExportDto>()
                .ForMember(x => x.Buyer, opt => 
                    opt.MapFrom(y => $"{y.Buyer.FirstName} {y.Buyer.LastName}"));

            this.CreateMap<User, UserSoldProductExportDto>();

            this.CreateMap<Category, CategoryProductsExportDto>()
                .ForMember(x => x.Count, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Count()))
                .ForMember(x => x.AveragePrice, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Average(z => z.Product.Price)))
                .ForMember(x => x.TotalRevenue, opt =>
                    opt.MapFrom(y => y.CategoryProducts.Sum(z => z.Product.Price)));
        }
    }
}
