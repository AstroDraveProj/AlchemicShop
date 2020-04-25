using AlchemicShop.BLL.DTO;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;

namespace AlchemicShop.WEB.Helper
{
    public class Mapper
    {
        #region CategoryDTO
        public static CategoryDTO CategoryMap(CategoryViewModel categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryViewModel, CategoryDTO>()).CreateMapper();
            var f = mapper.Map<CategoryViewModel, CategoryDTO>(categoryDTO);
            return f;
        }
        public static CategoryViewModel CategoryMap(CategoryDTO category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var f = mapper.Map<CategoryDTO, CategoryViewModel>(category);
            return f;
        }
        public static List<CategoryViewModel> CategoryMap(List<CategoryDTO> category)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryDTO, CategoryViewModel>(); }).CreateMapper();
            var f = mapper.Map<List<CategoryDTO>, List<CategoryViewModel>>(category);
            return f;
        }
        #endregion
    }
}