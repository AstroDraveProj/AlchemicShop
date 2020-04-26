using AlchemicShop.BLL.DTO;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;

namespace AlchemicShop.WEB.Helpers
{
    public class Mapper
    {
        #region CategoryDTO
        public static CategoryDTO CategoryMap(CategoryViewModel categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryViewModel, CategoryDTO>()).CreateMapper();
            var category = mapper.Map<CategoryViewModel, CategoryDTO>(categoryDTO);
            return category;
        }
        public static CategoryViewModel CategoryMap(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categoryDTO = mapper.Map<CategoryDTO, CategoryViewModel>(category);
            return categoryDTO;
        }
        public static List<CategoryViewModel> CategoryMap(List<CategoryDTO> category)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryDTO, CategoryViewModel>(); }).CreateMapper();
            var listCategory = mapper.Map<List<CategoryDTO>, List<CategoryViewModel>>(category);
            return listCategory;
        }
        #endregion
    }
}