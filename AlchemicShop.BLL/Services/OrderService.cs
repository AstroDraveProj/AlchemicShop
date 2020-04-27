using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddOrder(OrderDTO orderProductDTO)
        {
           
        }
        public IEnumerable<OrderDTO> GetOrders()
        {
            return Mapper.Mapping<Order, OrderDTO>(Database.Orders.GetAll().ToList());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказа", "");
            }
            var order = Database.Orders.Get(id.Value);
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }

            var orderDTO = Mapper.Mapping<Order, OrderDTO>(order);
            return orderDTO;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
