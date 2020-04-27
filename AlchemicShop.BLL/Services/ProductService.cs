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
    public class ProductService : IProductService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            Database = uow;
        }

        public void AddProduct(ProductDTO productDTO)
        {
            var category = Database.Categories.Get(productDTO.CategoryId);

            // валидация
            if (category == null)
            {
                throw new ValidationException("Категория не найдена", "");
            }
            Product product = new Product
            {
                Name = productDTO.Name,
                Amount = productDTO.Amount,
                CategoryId = category.Id,
                Category = category,
                Description = productDTO.Description,
                Price = productDTO.Price,
                OrderProducts = null // потому что как только мы добавили продукт его ещё не заказывали
            };
            Database.Products.Create(product);
            Database.Save();
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(Database.Products.GetAll().ToList());
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id продукта", "");
            }

            var product = Database.Products.Get(id.Value);
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }

            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
