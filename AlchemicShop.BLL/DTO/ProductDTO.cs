using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public virtual CategoryDTO CategoryDTO { get; set; }

        public virtual ICollection<OrderProductDTO> OrderProductsDTO { get; set; }
    }
}
