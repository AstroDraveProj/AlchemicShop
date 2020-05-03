using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class UserRoleRepository : IRepository<UserRole>
    {
        private AlchemicShopContext _dbContext;

        public UserRoleRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public Task Create(UserRole item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserRole item)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> Find(Func<UserRole, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRole>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserRole item)
        {
            throw new NotImplementedException();
        }
    }
}
