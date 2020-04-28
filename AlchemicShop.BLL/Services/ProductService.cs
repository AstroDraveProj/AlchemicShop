using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;

namespace AlchemicShop.BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _dbOperation;

        public ProductService(IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public void AddProduct(ProductDTO productDTO)
        {
            //var category = _dbOperation.Categories.Get(productDTO.CategoryId);

            //// валидация
            //if (category == null)
            //{
            //    throw new ValidationException("Категория не найдена", "");
            //}
            //Product product = new Product
            //{
            //    Name = productDTO.Name,
            //    Amount = productDTO.Amount,
            //    CategoryId = category.Id,
            //    Category = category,
            //    Description = productDTO.Description,
            //    Price = productDTO.Price,
            //    OrderProducts = null // потому что как только мы добавили продукт его ещё не заказывали
            //};
            //_dbOperation.Products.Create(product);
            _dbOperation.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = Mapper.Mapping<Product, ProductDTO>(_dbOperation.Products.GetAll().ToList());
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

            var productDto = Mapper.Mapping<Product, ProductDTO>(product);
            return productDto;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
