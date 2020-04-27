using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.BLL.Services;
using AlchemicShop.WEB.Helpers;
using AlchemicShop.WEB.Models;
using AutoMapper;
using Ninject.Modules;

namespace AlchemicShop.WEB.IoC
{
    public class AlchemicShopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IProductService>().To<ProductService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IOrderProductService>().To<OrderProductService>();
            Bind<IUserService>().To<UserService>();

            var configur = Mapper.Configure();

            Bind<IMapper>().ToConstant(configur.CreateMapper());
            // Bind(configur.CreateMapper()).To<IMapper>();    
            //Bind<IMapper>().ToMethod(c => configur.CreateMapper());
        }

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


}