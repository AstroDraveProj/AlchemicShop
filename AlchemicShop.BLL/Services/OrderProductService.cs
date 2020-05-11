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
            return _mapper.Map<IEnumerable<OrderProductDTO>>
                (await _dbOperation.OrderProducts.GetAllAsync()).ToList();
        }

        public async Task<OrderProductDTO> GetOrderProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказанного продукта", "");
            }
            var orderProduct = await _dbOperation.OrderProducts.GetIdAsync(id);
            if (orderProduct == null)
            {
                throw new ValidationException("Заказаный продукт не найден", "");
            }
            return _mapper.Map<OrderProductDTO>(orderProduct);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProductsId(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id заказанного продукта", "");
            }

            var products = await _dbOperation.OrderProducts.GetAllAsync();
            products = products.Where(x => x.OrderId == id).ToList();

            if (products == null)
            {
                throw new ValidationException("Заказаный продукт не найден", "");
            }
            return _mapper.Map<IEnumerable<OrderProductDTO>>(products);
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
