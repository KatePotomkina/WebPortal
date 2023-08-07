using AutoMapper;
using BackPart.Data.DTO;
using BackPart.Data.DTO.Response;
using BackPart.Models;

//using BackPart.Models;

namespace BackPart.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderRersponse>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.CustomerId))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            ;
        CreateMap<Customer, CustomerResponse>();
        CreateMap<Product, ProductResponse>();
        CreateMap<OrderItem, OrderItemResponse>();
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
            .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.Customer.CustomerAdress));

    }
}