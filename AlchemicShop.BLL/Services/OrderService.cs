using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;

namespace AlchemicShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _dbOperation { get; set; }
        public OrderService(IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Create(Mapper.Mapping<OrderDTO, Order>(orderDTO));
        }

        public void DeleteOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Delete(Mapper.Mapping<OrderDTO, Order>(orderDTO));
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Update(Mapper.Mapping<OrderDTO, Order>(orderDTO));
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return Mapper.Mapping<Order, OrderDTO>(_dbOperation.Orders.GetAll().ToList());
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

            var orderDTO = Mapper.Mapping<Order, OrderDTO>(order);
            return orderDTO;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
