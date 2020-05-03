using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;

namespace AlchemicShop.BLL.Helpers
{
    public class BLLProfile : Profile
    {
        public BLLProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRole>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
