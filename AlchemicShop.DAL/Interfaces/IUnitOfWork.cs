using AlchemicShop.DAL.Entities;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<User> Users { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderProduct> OrderProducts { get; }

        void Save();
    }
}
