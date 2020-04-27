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
        IUnitOfWork Database { get; set; }
        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category = Mapper.CategoryMap(categoryDTO);
           // Category category = new Category { Name = categoryDTO.Name };
            Database.Categories.Create(category);
            Database.Save();
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return Mapper.CategoryMap(Database.Categories.GetAll().ToList());
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

            var categoryDto = Mapper.CategoryMap(category);
            return categoryDto;
            //new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}