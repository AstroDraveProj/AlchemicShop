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
        private readonly IMapper _mapper;
        public ShoppingCartService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public int GetMax()
        {
            return _dbOperation.MaxOrder.GetMax();
        }
    }
}
