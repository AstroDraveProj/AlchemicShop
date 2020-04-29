using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class OrderProductViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual OrderViewModel OrderViewModel { get; set; }

        public virtual ProductViewModel ProductViewModel { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}