using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
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

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            await _dbOperation.Categories.Create(category);
            await _dbOperation.Save();
        }

        public async Task EditCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            await _dbOperation.Categories.Update(category);
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _dbOperation.Categories.GetAll();
            var res = _mapper.Map<List<CategoryDTO>>(categories);
            return res;
        }

        public async Task DeleteCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var category = await _dbOperation.Categories.Get(id.Value);
            if (category == null)
            {
                throw new ValidationException("Категория не найден", "");
            }
            await _dbOperation.Categories.Delete(category);
            await _dbOperation.Save();

        }

        public async Task<CategoryDTO> GetCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var category = await _dbOperation.Categories.Get(id.Value);
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