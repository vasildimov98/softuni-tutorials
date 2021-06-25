namespace CarDealer
{
    using AutoMapper;

    using Models;
    using DTO.Import;
    using DTO.Export;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierImportDto, Supplier>();

            this.CreateMap<PartImportDto, Part>();

            this.CreateMap<CarImportDto, Car>();

            this.CreateMap<CustomerImportDto, Customer>();

            this.CreateMap<SaleImportDto, Sale>();

            this.CreateMap<Customer, CustomerExportDto>()
                .ForMember(x => x.BirthDate, opt =>
                    opt.MapFrom(y => y.BirthDate.ToString("dd/MM/yyyy")));

            this.CreateMap<Car, CarMakeToyotaExport>();

            this.CreateMap<Supplier, SupplierExportDto>();

            this.CreateMap<Car, CarPartExportDto>()
                .ForMember(x => x.Car, opt =>
                    opt.MapFrom(y => new CarExport
                    {
                        Make = y.Make,
                        Model = y.Model,
                        TravelledDistance = y.TravelledDistance
                    }))
                .ForMember(x => x.PartCars, opt =>
                    opt.MapFrom(y => y.PartCars
                        .Select(z => new PartExport
                        {
                            Name = z.Part.Name,
                            Price = z.Part.Price.ToString("F2")
                        })));

            this.CreateMap<Customer, CustomerInfoExport>()
                .ForMember(x => x.SpentMoney, opt =>
                    opt.MapFrom(y => y.Sales.Sum(z => z.Car.PartCars.Sum(p => p.Part.Price))));

            this.CreateMap<Sale, SaleWithDiscountExport>()
                .ForMember(x => x.Car, opt =>
                    opt.MapFrom(y => y.Car))
                .ForMember(x => x.Discount, opt =>
                    opt.MapFrom(y => y.Discount.ToString("F2")))
                .ForMember(x => x.Price, opt =>
                    opt.MapFrom(y => y.Car.PartCars.Sum(z => z.Part.Price).ToString("F2")))
                .ForMember(x => x.PriceWithDiscount, opt =>
                    opt.MapFrom(y => (y.Car.PartCars.Sum(z => z.Part.Price) * (1 - (y.Discount / 100))).ToString("F2")));
        }
    }
}
