using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
