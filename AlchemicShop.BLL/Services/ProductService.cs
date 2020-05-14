using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public ProductService(
             IMapper mapper,
             IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            _dbOperation.Products.Create(_mapper.Map<Product>(productDTO));
            await _dbOperation.Save();
        }

        public async Task EditProduct(ProductDTO productDTO)
        {
            _dbOperation.Products.Update(_mapper.Map<Product>(productDTO));
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _dbOperation.Products.GetAllAsync());
        }

        public async Task Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = await _dbOperation.Products.GetIdAsync(id.Value);
            if (product != null)
            {
                _dbOperation.Products.Delete(product);
                await _dbOperation.Save();
            }
            else
            {
                throw new ValidationException("Продукт не найден", "");
            }
        }

        public async Task<ProductDTO> GetProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = await _dbOperation.Products.GetIdAsync(id.Value);
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> IsEnoughProduct(int? id, int? amount)
        {
            if (id == null || amount == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = await _dbOperation.Products.GetIdAsync(id.Value);

            if ((product.Amount - amount) >= 0)
                return true;
            return false;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
