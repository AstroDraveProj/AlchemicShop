using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;
using AutoMapper;

namespace AlchemicShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;
        public OrderService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Create(_mapper.Map<OrderDTO, Order>(orderDTO));
        }

        public void DeleteOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Delete(_mapper.Map<OrderDTO, Order>(orderDTO));
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Update(_mapper.Map<OrderDTO, Order>(orderDTO));
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return _mapper.Map<List<Order>, List<OrderDTO>>(_dbOperation.Orders.GetAll().ToList());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказа", "");
            }
            var order = _dbOperation.Orders.Get(id.Value);
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
