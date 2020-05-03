using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
       
        public int CustomerId { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }
        
        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public User Customer { get; set; }
       
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
