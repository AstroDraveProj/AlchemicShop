using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return dbContext.Categories.Where(predicate).ToList();
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
