using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;

namespace AlchemicShop.BLL.Helpers
{
    public class BLProfile : Profile
    {
        public BLProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
