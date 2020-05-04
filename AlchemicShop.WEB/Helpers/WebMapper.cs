using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.WEB.Models;
using AutoMapper;

namespace AlchemicShop.WEB.Helpers
{
    public static class WebMapper
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryViewModel>();

                cfg.CreateMap<ProductViewModel, ProductDTO>();
                cfg.CreateMap<ProductDTO, ProductViewModel>();

                cfg.CreateMap<UserViewModel, UserDTO>();
                cfg.CreateMap<UserDTO, UserViewModel>();

                cfg.CreateMap<RegisterViewModel, UserDTO>();
                cfg.CreateMap<UserDTO, RegisterViewModel>();

                cfg.CreateMap<OrderViewModel, OrderDTO>();
                cfg.CreateMap<OrderDTO, OrderViewModel>();

                cfg.CreateMap<OrderProductViewModel, OrderProductDTO>();
                cfg.CreateMap<OrderProductDTO, OrderProductViewModel>();

                cfg.AddProfile<BLLProfile>();
            });
            return config;
        }
    }
}