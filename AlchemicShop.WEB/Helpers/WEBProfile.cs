using AlchemicShop.BLL.DTO;
using AlchemicShop.WEB.Models;
using AutoMapper;

namespace AlchemicShop.WEB.Helpers
{
    public class WEBProfile : Profile
    {
        public WEBProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryDTO>();
        }
    }
}