namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(p => p.Name, pn =>
                    pn.MapFrom(cp => cp.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(pv => pv.Name, n =>
                    n.MapFrom(p => p.Name));

            //Employee
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(rev => rev.PositionId, p =>
                    p.MapFrom(p => p.Id))
                .ForMember(rev => rev.Name, n => 
                    n.MapFrom(p => p.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(ev => ev.Position, p =>
                    p.MapFrom(e => e.Position.Name));

            //Category
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(c => c.Name, n =>
                    n.MapFrom(cv => cv.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(cv => cv.CategoryId, ci => 
                    ci.MapFrom(c => c.Id));

            this.CreateMap<CreateItemInputModel, Item>()
                .ForMember(i => i.Price, p =>
                    p.MapFrom(cv => cv.Price));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(iv => iv.Category, c =>
                    c.MapFrom(i => i.Category.Name));

            //Orders
            this.CreateMap<Item, CreateOrderItemViewModel>();

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(ov => ov.PositionName, pn => pn.MapFrom(e => e.Position.Name));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(o => o.DateTime, dt =>
                    dt.MapFrom(cv => DateTime.UtcNow))
                .ForMember(o => o.Type, ot =>
                    ot.MapFrom(ot => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(ov => ov.Employee, e =>
                    e.MapFrom(o => o.Employee.Position.Name))
                .ForMember(ov => ov.DateTime, dt =>
                    dt.MapFrom(o => o.DateTime.ToString("D", CultureInfo.InvariantCulture)));
        }
    }
}
