using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<UserRole> Get(int? id)
        {
            return await _dbContext.UserRoles.FindAsync(id);
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            return await _dbContext.UserRoles.ToListAsync();
        }

        public Task Update(UserRole item)
        {
            throw new NotImplementedException();
        }
    }
}
