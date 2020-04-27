using AlchemicShop.BLL.DTO;
using AlchemicShop.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public static List<CategoryDTO> CategoryMap(List<Category> categoryList)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryDTO>(); }).CreateMapper();
            var categoryListDto = mapper.Map<List<Category>, List<CategoryDTO>>(categoryList);
            return categoryListDto;
        }
        #endregion

        #region Product
        public static Product ProductMap(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
            }).CreateMapper();
            var product = mapper.Map<ProductDTO, Product>(productDTO);
            return product;
        }
        public static ProductDTO ProductMap(Product product)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var productDTO = mapper.Map<Product, ProductDTO>(product);
            return productDTO;
        }
        public static List<ProductDTO> ProductMap(List<Product> productList)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var productListDto = mapper.Map<List<Product>, List<ProductDTO>>(productList);
            return productListDto;
        }
        #endregion

        #region OrderProduct
        public static OrderProduct OrderProductMap(OrderProductDTO orderProductDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderProductDTO, OrderProduct>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
            }).CreateMapper();
            var orderProduct = mapper.Map<OrderProductDTO, OrderProduct>(orderProductDTO);
            return orderProduct;
        }
        public static OrderProductDTO OrderProductMap(OrderProduct orderProduct)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var orderProductDTO = mapper.Map<OrderProduct, OrderProductDTO>(orderProduct);
            return orderProductDTO;
        }
        public static List<OrderProductDTO> OrderProductMap(List<OrderProduct> orderProductList)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var orderProductListDto = mapper.Map<List<OrderProduct>, List<OrderProductDTO>>(orderProductList);
            return orderProductListDto;
        }
        #endregion

        #region Order
        public static Order OrderMap(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<OrderProductDTO, OrderProduct>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
            }).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDTO);
            return order;
        }
        public static OrderDTO OrderMap(Order order)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }
        public static List<OrderDTO> OrderMap(List<Order> orderList)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var orderListDto = mapper.Map<List<Order>, List<OrderDTO>>(orderList);
            return orderListDto;
        }
        #endregion

        #region User
        public static User UserMap(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<OrderProductDTO, OrderProduct>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
            }).CreateMapper();
            var user = mapper.Map<UserDTO, User>(userDTO);
            return user;
        }
        public static UserDTO UserMap(User user)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var userDTO = mapper.Map<User, UserDTO>(user);
            return userDTO;
        }
        public static List<UserDTO> UserMap(List<User> userList)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            var userListDto = mapper.Map<List<User>, List<UserDTO>>(userList);
            return userListDto;
        }

        #endregion

    }
}
