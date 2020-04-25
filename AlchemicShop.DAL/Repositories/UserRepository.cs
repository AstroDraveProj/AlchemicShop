using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;


namespace AlchemicShop.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private AlchemicShopContext dbContext;

        public UserRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }
        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
