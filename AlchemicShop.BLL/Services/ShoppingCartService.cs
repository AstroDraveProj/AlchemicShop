using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _dbOperation;
        public ShoppingCartService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public int GetMax()
        {
            return _dbOperation.MaxOrder.GetMax();
        }

        public int GetOrderId(string s)
        {
            return _dbOperation.MaxOrder.GetMaxId(s);
        }
    }
}
