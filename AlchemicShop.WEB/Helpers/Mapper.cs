using AlchemicShop.BLL.DTO;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;

namespace AlchemicShop.WEB.Helpers
{
    public static class Mapper
    {
        private static IMapper mapperConfig;

        static Mapper()
        {
            mapperConfig = new MapperConfiguration(cfg =>
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
            }).CreateMapper();
        }

        public static TDestination Mapping<TSource, TDestination>(TSource source)
        {
            return mapperConfig.Map<TSource, TDestination>(source);
        }

        public static List<TDestination> Mapping<TSource, TDestination>(List<TSource> source)
        {
            return mapperConfig.Map<List<TSource>, List<TDestination>>(source);
        }
    }
}