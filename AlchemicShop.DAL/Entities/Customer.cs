using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemicShop.DAL.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
