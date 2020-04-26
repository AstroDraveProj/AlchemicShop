using AlchemicShop.BLL.DTO;
using System.Collections.Generic;

namespace AlchemicShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(CategoryDTO categoryDto);
        CategoryDTO GetCategory(int? id);
        IEnumerable<CategoryDTO> GetCategories();
        void Dispose();
    }
}