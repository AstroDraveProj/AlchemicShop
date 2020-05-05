﻿using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IShoppingCart<T> where T : class
    {
        Task<int> GetMaxOrderIdAsync();
    }
}
