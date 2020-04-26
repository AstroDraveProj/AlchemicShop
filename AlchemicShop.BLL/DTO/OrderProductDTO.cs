using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.BLL.DTO
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual OrderDTO Order { get; set; }

        public virtual ProductDTO Product { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
