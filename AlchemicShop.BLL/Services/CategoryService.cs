using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AlchemicShop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private  IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            Database = uow;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            //var category = Mapper.CategoryMap(categoryDTO);
            Category category = new Category { Name = categoryDTO.Name };
            Database.Categories.Create(category);
            Database.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = Database.Categories.GetAll().ToList();
             return _mapper.Map<CategoryDTO>(categories);
        }

        public IEnumerable<ProductDTO> GetProducts(CategoryDTO categoryDTO)
        {
            return Mapper.Mapping<Product, ProductDTO>(Database.Products.Find(p=>p.CategoryId==Mapper.Mapping<CategoryDTO, Category>(categoryDTO).Id).ToList());
        }

        public CategoryDTO GetCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var category = Database.Categories.Get(id.Value);
            if (category == null)
            {
                throw new ValidationException("Категория не найдена", "");
            }

            var categoryDto =  Mapper.CategoryMap(category);
            return categoryDto;
            //new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
