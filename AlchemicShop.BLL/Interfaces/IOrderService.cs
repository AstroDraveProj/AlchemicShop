using System;
using System.Collections.Generic;
using AlchemicShop.BLL.DTO;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderDTO orderDto);
        OrderDTO GetOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        void Dispose();
    }
}