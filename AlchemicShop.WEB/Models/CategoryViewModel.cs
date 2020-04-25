using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<ProductViewModel> ProductViewModels { get; set; }
    }
}