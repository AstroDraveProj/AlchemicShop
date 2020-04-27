using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AlchemicShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            Database = uow;
        }

        public void AddOrder(OrderDTO orderProductDTO)
        {

        }
        public IEnumerable<OrderDTO> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(Database.Orders.GetAll().ToList());
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

            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
