using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;

namespace AlchemicShop.BLL.Helpers
{
    public static class BllMapper
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();

                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<OrderProductDTO, OrderProduct>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
            });
            return config;
        }
    }
}