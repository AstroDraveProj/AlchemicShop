using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);

        void Delete(T item);

        void Update(T item);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindItemAsync(Func<T, bool> item);

        Task<T> GetIdAsync(int? id);
    }
}
