using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemicShop.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80), Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }

        [ForeignKey("PotionType")]
        public int? PotionTypeId { get; set; }
        public virtual PotionType PotionType { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public virtual PotionType Manager { get; set; }

        public ICollection<ShopingCart> ShopingCarts { get; set; }
    }
}
