using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork _dbOperation { get; set; }
        public CategoryService(IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category = Mapper.Mapping<CategoryDTO, Category>(categoryDTO);
            // Category category = new Category { Name = categoryDTO.Name };
            _dbOperation.Categories.Create(category);
            _dbOperation.Save();
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return Mapper.Mapping<Category, CategoryDTO>(_dbOperation.Categories.GetAll().ToList());
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var category = _dbOperation.Categories.Get(id.Value);
            if (category == null)
            {
                throw new ValidationException("Категория не найден", "");
            }
            _dbOperation.Categories.Delete(category);

        }

        public CategoryDTO GetCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var category = _dbOperation.Categories.Get(id.Value);
            if (category == null)
            {
                throw new ValidationException("Категория не найдена", "");
            }

            var categoryDto = Mapper.Mapping<Category, CategoryDTO>(category);
            return categoryDto;
            //new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}