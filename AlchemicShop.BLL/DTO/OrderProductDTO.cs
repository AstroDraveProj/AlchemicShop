using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.BLL.DTO
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public OrderDTO Order { get; set; }

        public ProductDTO Product { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
