using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
            _dbOperation.Orders.Create(
                _mapper.Map<Order>(orderDTO));
            await _dbOperation.Save();
        }

        public async Task DeleteOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Delete(
                _mapper.Map<Order>(orderDTO));
            await _dbOperation.Save();
        }

        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            _dbOperation.Orders.Update(
                _mapper.Map<Order>(orderDTO));
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(
                await _dbOperation.Orders.GetAllAsync());
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

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrderList(int idUser)
        {
            var orders = await _dbOperation.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>
                (orders.Where(x => x.UserId == idUser).ToList());
        }

        public async Task<float> GetOrderSum(int? idOrder)
        {
            var products = await _dbOperation.OrderProducts.GetAllAsync();
            float sumOrder = 0;

            foreach (var item in products)
            {
                if (item.OrderId == idOrder)
                {
                    sumOrder = sumOrder + (item.Amount * item.Product.Price);
                }
            }
            return sumOrder;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
