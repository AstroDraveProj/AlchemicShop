using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddOrder(OrderDTO orderDTO)
        {
            var orders = _mapper.Map<OrderDTO, Order>(orderDTO);
            _dbOperation.Orders.Create(orders);
            await _dbOperation.Save();
        }

        public async Task DeleteOrder(OrderDTO orderDTO)
        {
            var deletingOrder = _mapper.Map<OrderDTO, Order>(orderDTO);
            _dbOperation.Orders.Delete(deletingOrder);
            await _dbOperation.Save();
        }

        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            var updatingOrder = _mapper.Map<OrderDTO, Order>(orderDTO);
            _dbOperation.Orders.Update(updatingOrder);
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var ordersList = await _dbOperation.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(ordersList);
        }

        public async Task<OrderDTO> GetOrder(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказа", "");
            }
            var order = await _dbOperation.Orders.GetIdAsync(id.Value);
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
