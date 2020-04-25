using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace AlchemicShop.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private AlchemicShopContext dbContext;
        
        public ProductRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delte(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
