using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductDTO> ProductsDTO { get; set; }
    }
}
