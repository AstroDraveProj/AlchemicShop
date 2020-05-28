using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please, enter name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Product name is incorrect")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter amount")]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please, enter price of")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Should be like: 12,13")]
        public float Price { get; set; }

        public CategoryViewModel CategoryViewModels { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }
    }
}