using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T item);

        Task Delete(T item);

        Task Update(T item);

        Task<IEnumerable<T>> GetAll();

        Task<T> Find(Func<T, bool> predicate);

        Task<T> Get(int? id);
    }
}
