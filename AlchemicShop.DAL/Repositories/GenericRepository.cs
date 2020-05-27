using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AlchemicShopContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AlchemicShopContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Create(TEntity item)
        {
            if (item != null)
            {
                _dbSet.Add(item);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Delete(TEntity item)
        {
            var deleteItem = _dbSet.Find(item.Id);
            if (deleteItem != null)
            {
                _dbSet.Remove(deleteItem);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<TEntity> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbSet.FindAsync(id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<TEntity> FindItemAsync(Func<TEntity, bool> item)
        {
            return await Task.Run(() => _dbSet.Where(item).FirstOrDefault());
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
