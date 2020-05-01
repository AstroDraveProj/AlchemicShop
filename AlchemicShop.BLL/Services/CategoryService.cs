using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
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

        public  AddCategory(CategoryDTO categoryDTO)
        {
            //var category = Mapper.Mapping<CategoryDTO, Category>(categoryDTO);
            //// Category category = new Category { Name = categoryDTO.Name };
            //_dbOperation.Categories.Create(category);
             _dbOperation.Save();
        }

        public void EditCategory(CategoryDTO categoryDTO)
        {
            //var category = Mapper.Mapping<CategoryDTO, Category>(categoryDTO);
            //_dbOperation.Categories.Update(category);
            _dbOperation.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            // return Mapper.Mapping<Category, CategoryDTO>(_dbOperation.Categories.GetAll().ToList());
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

            }

            //var categoryDto = null /* = Mapper.Mapping<Category, CategoryDTO>(category)*/;
            //return categoryDto; 
            throw new ValidationException("Категория не найдена", "");
            //new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}