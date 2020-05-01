using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryDTO categoryDto);

        Task<CategoryDTO> GetCategory(int? id);

        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task EditCategory(CategoryDTO categoryDTO);

        Task DeleteCategory(int? id);

        void Dispose();
    }
}