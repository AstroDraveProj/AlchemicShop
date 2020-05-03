﻿using AlchemicShop.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<User> Users { get; }

        IRepository<UserRole> UserRoles { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderProduct> OrderProducts { get; }

        IShoppingCart<Order> MaxOrder { get; }

        Task Save();
    }
}
