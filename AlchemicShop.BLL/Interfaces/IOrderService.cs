using System.Collections.Generic;
using System.Threading.Tasks;
using AlchemicShop.BLL.DTO;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderDTO orderDto);

        Task DeleteOrder(OrderDTO orderDto);

        Task UpdateOrder(OrderDTO orderDto);

        Task<OrderDTO> GetOrder(int? id);

        Task<IEnumerable<OrderDTO>> GetOrders();

        void Dispose();
    }
}