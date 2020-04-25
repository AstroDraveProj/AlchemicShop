using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
