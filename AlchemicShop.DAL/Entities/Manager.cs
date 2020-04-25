using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemicShop.DAL.Entities
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80), Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
