using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemicShop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status StatusDTO { get; set; }

        public UserDTO User { get; set; }

        public virtual ICollection<OrderProductDTO> OrderProductsDTO { get; set; }
    }
}
