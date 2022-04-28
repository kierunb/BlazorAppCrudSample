using AutoMapper;
using BlazorAppCrudDorota.Server.Database;
using BlazorAppCrudDorota.Shared.ViewModels;

namespace BlazorAppCrudDorota.Server.Profiles;

public class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<Orders, OrderView>().ReverseMap();
    }
}
