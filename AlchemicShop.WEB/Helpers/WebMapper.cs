using AlchemicShop.BLL.DTO;
using AlchemicShop.WEB.Models;
using AutoMapper;

namespace AlchemicShop.WEB.Helpers
{
    public static class Mapper
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDTO>();
                cfg.CreateMap<OrderViewModel, OrderDTO>();
                cfg.CreateMap<OrderProductViewModel, OrderProductDTO>();
                cfg.CreateMap<ProductViewModel, ProductDTO>();
                cfg.CreateMap<CategoryViewModel, CategoryDTO>();

                cfg.CreateMap<UserDTO, UserViewModel>();
                cfg.CreateMap<OrderDTO, OrderViewModel>();
                cfg.CreateMap<OrderProductDTO, OrderProductViewModel>();
                cfg.CreateMap<ProductDTO, ProductViewModel>();
                cfg.CreateMap<CategoryDTO, CategoryViewModel>();
            });
            return config;
        }
    }
}