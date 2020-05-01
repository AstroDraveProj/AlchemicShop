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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;
        public CategoryService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);          
            _dbOperation.Categories.Create(category);
            _dbOperation.Save();
        }

        public void EditCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            _dbOperation.Categories.Update(category);
            _dbOperation.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var res =  _mapper.Map<List<CategoryDTO>>(_dbOperation.Categories.GetAll());
           return res;
        }

        public void DeleteCategory(int? id)
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
            _dbOperation.Save();

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
            var categoryDto = _mapper.Map<Category, CategoryDTO>(category);
            return categoryDto;
        }
        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}