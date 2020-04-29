using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter name of category")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Category name is incorrect")]
        public string Name { get; set; }

        public ICollection<ProductViewModel> ProductViewModels { get; set; }
    }
}