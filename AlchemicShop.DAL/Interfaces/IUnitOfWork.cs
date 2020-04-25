using AlchemicShop.DAL.Entities;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        void Save();
    }
}
