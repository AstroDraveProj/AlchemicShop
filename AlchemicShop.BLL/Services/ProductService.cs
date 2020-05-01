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
            var category = _dbOperation.Categories.Get(productDTO.CategoryId);

            if (category == null)
            {
                throw new ValidationException("Категория не найдена", "");
            }
            var product = new Product
            {
                Name = productDTO.Name,
                Amount = productDTO.Amount,
                CategoryId = category.Id,
                Description = productDTO.Description,
                Price = productDTO.Price
            };
            await Task.Run(() => _dbOperation.Products.Create(product));
           await Task.Run(()=> _dbOperation.Save());
        }

        public void EditProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            _dbOperation.Products.Update(product);
            _dbOperation.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _mapper.Map<List<Product>, List<ProductDTO>>(_dbOperation.Products.GetAll().ToList());
            return products;
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = _dbOperation.Products.Get(id.Value);
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }
            _dbOperation.Products.Delete(product);
            _dbOperation.Save();

        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = _dbOperation.Products.Get(id.Value);
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }

            var productDto = _mapper.Map<Product, ProductDTO>(product);
            return productDto;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
