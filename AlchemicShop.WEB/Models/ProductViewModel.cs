using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter name of product")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Product name is incorrect")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter amount of product")]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please, enter price of product")]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        public int CategoryId { get; set; }

        public CategoryViewModel CategoryViewModels { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }

    }
}