namespace ProductShop
{
    using AutoMapper;

    using Models;
    using DTO.Product;
    using ProductShop.DTO.User;
    using ProductShop.DTO.Categories;
    using System.Linq;
    using System.Globalization;
    using ProductShop.DTO.UserWithProducts;
    using ProductShop.Data;
    using System.Collections.Generic;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Products 
            this.CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Seller, y =>
                    y.MapFrom(z => $"{(z.Seller.FirstName != null ? z.Seller.FirstName + " " : string.Empty)}{(z.Seller.LastName ?? string.Empty)}"));

            //Users
            this.CreateMap<Product, ProductUserDTO>()
                .ForMember(x => x.BuyerFirstName, y =>
                    y.MapFrom(z => z.Buyer.FirstName ?? string.Empty))
                .ForMember(x => x.BuyerLastName, y =>
                    y.MapFrom(z => z.Buyer.LastName ?? string.Empty));

            this.CreateMap<User, UserDTO>()
                .ForMember(x => x.SoldProducts, y =>
                    y.MapFrom(z => z.ProductsSold
                                        .Where(ps => ps.Buyer != null)));

            //Category
            this.CreateMap<Category, CategoryDTO>()
                .ForMember(x => x.Category, y =>
                    y.MapFrom(z => z.Name))
                .ForMember(x => x.ProductsCount, y =>
                    y.MapFrom(z => z.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y =>
                    y.MapFrom(z => z.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2", CultureInfo.InvariantCulture)))
                .ForMember(x => x.TotalRevenue, y =>
                    y.MapFrom(z => z.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2", CultureInfo.InvariantCulture)));

            //User With Products
            this.CreateMap<Product, ProductInfoDTO>();

            this.CreateMap<ICollection<Product>, UserSoldProductsDTO>()
                .ForMember(x => x.Count, y =>
                    y.MapFrom(z => z.Count(p => p.Buyer != null)))
                .ForMember(x => x.Products, y =>
                    y.MapFrom(z => z.Where(p => p.Buyer != null)));

            this.CreateMap<User, UserInfoDTO>()
                .ForMember(x => x.SoldProducts, y =>
                    y.MapFrom(z => z.ProductsSold));
        }
    }
}
