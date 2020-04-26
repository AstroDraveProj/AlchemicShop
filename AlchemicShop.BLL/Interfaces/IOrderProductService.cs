using AlchemicShop.BLL.DTO;
using System.Collections.Generic;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IOrderProductService
    {
        void AddOrderProduct(OrderProductDTO orderProductDto);
        OrderProductDTO GetOrderProduct(int? id);
        IEnumerable<OrderProductDTO> GetOrderProducts();
        void Dispose();
    }
}