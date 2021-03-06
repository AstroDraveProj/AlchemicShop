﻿using AlchemicShop.BLL.Interfaces;
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
            Bind<IShoppingCartService>().To<ShoppingCartService>();
            Bind<ISortService>().To<SortingService>();
            Bind<IMapper>().ToConstant(WebMapper.Configure().CreateMapper());
        }
    }
}