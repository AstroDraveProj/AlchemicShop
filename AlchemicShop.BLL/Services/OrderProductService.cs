using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;
using AutoMapper;
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
            var product = await _dbOperation.Products.Get(orderProductDTO.ProductId);
            var order = await _dbOperation.Orders.Get(orderProductDTO.OrderId);
            // валидация
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }
            OrderProduct orderProduct = new OrderProduct
            {
                ProductId = product.Id,
                Product = product,
                Amount = orderProductDTO.Amount,
                OrderId = order.Id,
                Order = order
            };
            await _dbOperation.OrderProducts.Create(orderProduct);
            await _dbOperation.Save();
        }
        public async Task<IEnumerable<OrderProductDTO>> GetOrderProducts()
        {
            var orderProducts = await _dbOperation.OrderProducts.GetAll();
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(orderProducts);
        }

        public async Task<OrderProductDTO> GetOrderProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказанного продукта", "");
            }
            var orderProduct = await _dbOperation.OrderProducts.Get(id.Value);
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
