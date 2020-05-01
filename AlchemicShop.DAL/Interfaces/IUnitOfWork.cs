using AlchemicShop.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<User> Users { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderProduct> OrderProducts { get; }

        IAccount<User> Accounts { get; }

        Task Save();
    }
}
