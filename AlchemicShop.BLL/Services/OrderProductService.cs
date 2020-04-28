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
    public class OrderProductService : IOrderProductService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;
        public OrderProductService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            Database = uow;
        }

        public void AddOrderProduct(OrderProductDTO orderProductDTO)
        {
            var product = Database.Products.Get(orderProductDTO.ProductId);
            var order = Database.Orders.Get(orderProductDTO.OrderId);
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
            Database.OrderProducts.Create(orderProduct);
            Database.Save();
        }
        public IEnumerable<OrderProductDTO> GetOrderProducts()
        {
            return _mapper.Map<IEnumerable<OrderProductDTO>>(Database.OrderProducts.GetAll().ToList());
        }

        public OrderProductDTO GetOrderProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказанного продукта", "");
            }
            var orderProduct = Database.OrderProducts.Get(id.Value);
            if (orderProduct == null)
            {
                throw new ValidationException("Заказаный продукт не найден", "");
            }

            var orderProductDTO = _mapper.Map<OrderProductDTO>(orderProduct);
            return orderProductDTO;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
