using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;

namespace AlchemicShop.DAL.Repositories
{
    public class UoWItems : IUnitOfWork
    {
        private AlchemicShopContext dbContext;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;

        public UoWItems(string connection)
        {
            dbContext = new AlchemicShopContext(connection);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(dbContext);
                return categoryRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
