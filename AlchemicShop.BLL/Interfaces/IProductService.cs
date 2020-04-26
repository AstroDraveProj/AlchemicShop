﻿using AlchemicShop.BLL.DTO;
using System.Collections.Generic;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDTO productDto);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}