using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public StatusDTO StatusDTO { get; set; }

        public virtual ICollection<UserDTO> UsersDTO { get; set; }

        public virtual ICollection<OrderProductDTO> OrderProductsDTO { get; set; }
    }
}
