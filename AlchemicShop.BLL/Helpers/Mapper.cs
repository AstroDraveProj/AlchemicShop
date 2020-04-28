using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace AlchemicShop.BLL.Helpers
{
    public static class Mapper
    {
        private static IMapper mapperConfig;
        static Mapper()
        {
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
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