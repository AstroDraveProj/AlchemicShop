using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IOrderProductService
    {
        Task AddOrderProduct(OrderProductDTO orderProductDto);

        Task<OrderProductDTO> GetOrderProduct(int? id);

        Task<IEnumerable<OrderProductDTO>> GetOrderProducts();

        void Dispose();
    }
}