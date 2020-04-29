using System;
using System.Collections.Generic;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);

        void Delete(T item);

        void Update(T item);

        IEnumerable<T> GetAll();
    
        IEnumerable<T> Find(Func<T, bool> predicate);
     
        T Get(int? id);
    }
}
