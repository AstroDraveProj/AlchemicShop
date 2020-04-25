using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace AlchemicShop.BLL.Helpers
{
    public static class Mapper
    {
        #region Category
        public static Category CategoryMap(CategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()).CreateMapper();
            var category = mapper.Map<CategoryDTO, Category>(categoryDTO);
            return category;
        }
        public static CategoryDTO CategoryMap(Category category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            var categoryDTO = mapper.Map<Category, CategoryDTO>(category);
            return categoryDTO;
        }
        public static List<CategoryDTO> CategoryMap(List<Category> category)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryDTO>(); }).CreateMapper();
            var listCategory = mapper.Map<List<Category>, List<CategoryDTO>>(category);
            return listCategory;
        }
        #endregion
    }
}
