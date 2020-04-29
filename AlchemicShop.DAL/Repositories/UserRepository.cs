using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private AlchemicShopContext _dbContext;

        public UserRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public void Create(User item)
        {
            if (item != null)
            {
                _dbContext.Users.Add(item);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(User item)
        {
            var deleteItem = Get(item.Id);
            if (deleteItem != null)
            {
                _dbContext.Users.Remove(deleteItem);
            //    _dbContext.SaveChanges();
            }
        }

        public User Get(int? id)
        {
            if (id != null)
            {
                return _dbContext.Users.Find(id);
            }
            throw new ValidationException();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _dbContext.Users.Where(predicate).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Update(User item)
        {
            if (item != null)
            {
                var updateItem = _dbContext.Users.Find(item.Id);

                if (updateItem != null)
                {
                    updateItem.IsAdmin = item.IsAdmin;
                    updateItem.Login = item.Login;
                    updateItem.Name = item.Name;
                    _dbContext.SaveChanges();
                }

            }
        }
    }
}
