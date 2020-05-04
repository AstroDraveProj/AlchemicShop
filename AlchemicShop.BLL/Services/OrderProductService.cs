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
    public class OrderProductService : IOrderProductService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;
        public OrderProductService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task AddOrderProduct(OrderProductDTO orderProductDTO)
        {
             _dbOperation.OrderProducts.Create(_mapper.Map<OrderProduct>(orderProductDTO));
            await _dbOperation.Save();
        }
        public async Task<IEnumerable<OrderProductDTO>> GetOrderProducts()
        {
            var orderProducts = await _dbOperation.OrderProducts.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(orderProducts);
        }

        public async Task<OrderProductDTO> GetOrderProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказанного продукта", "");
            }
            var orderProduct = await _dbOperation.OrderProducts.GetIdAsync(id.Value);
            if (orderProduct == null)
            {
                throw new ValidationException("Заказаный продукт не найден", "");
            }

            var orderProductDTO = _mapper.Map<OrderProduct, OrderProductDTO>(orderProduct);
            return orderProductDTO;
        }
        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
