using AlchemicShop.DAL.Entities;
using System;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<User> Users { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderProduct> OrderProducts { get; }

        void Save();
    }
}
