using System;
using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<OrderProductDTO> OrderProductsDTO { get; set; }
    }
}
