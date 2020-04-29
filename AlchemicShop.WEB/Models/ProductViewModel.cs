using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public int CategoryId { get; set; }

        public CategoryViewModel CategoryViewModels { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }

    }
}