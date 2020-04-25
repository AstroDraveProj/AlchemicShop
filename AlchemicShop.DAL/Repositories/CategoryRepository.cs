using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace AlchemicShop.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private AlchemicShopContext dbContext;

        public CategoryRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }
        public void Create(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delte(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
