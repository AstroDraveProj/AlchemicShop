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
            await _dbOperation.Categories.Create(_mapper.Map<Category>(categoryDTO));
            await _dbOperation.Save();
        }

        public async Task EditCategory(CategoryDTO categoryDTO)
        {
            await _dbOperation.Categories.Update(_mapper.Map<Category>(categoryDTO));
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<List<CategoryDTO>>(await _dbOperation.Categories.GetAll());
        }

        public async Task DeleteCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Category not found", "");
            }

            var category = await _dbOperation.Categories.Get(id.Value);
            if (category != null)
            {
                await _dbOperation.Categories.Delete(category);
                await _dbOperation.Save();
            }
            else
            {
                throw new ValidationException("Category not found", "");
            }
        }

        public async Task<CategoryDTO> GetCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Category not found", "");
            }

            var category = await _dbOperation.Categories.Get(id.Value);
            if (category == null)
            {
                throw new ValidationException("Category not found", "");
            }
            return _mapper.Map<CategoryDTO>(category);
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}