using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.BLL.Services;
using AlchemicShop.WEB.Helpers;
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

            var mapperConfiguration = new MapperConfiguration(cfg => { CreateConfiguration(); });
            Bind<IMapper>().ToConstructor(c => new AutoMapper.Mapper(mapperConfiguration)).InSingletonScope();

        }

        public static MapperConfiguration CreateConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WEBProfile());  //mapping between Web and Business layer objects
                cfg.AddProfile(new BLProfile());  // mapping between Business and DB layer objects
            });

            return config;
        }
    }

    
}