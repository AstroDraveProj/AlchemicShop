using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<ProductDTO> ProductsDTO { get; set; }
    }
}
