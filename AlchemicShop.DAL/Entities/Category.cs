using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.DAL.Entities
{
    public class Category: BaseEntity
    {

        [Required, MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}