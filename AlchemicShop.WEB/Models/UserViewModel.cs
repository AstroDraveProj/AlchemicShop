using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter login")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Login is incorrect (a-zA-Z)")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "At least 6 chars", MinimumLength = 6)]

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<OrderViewModel> OrdersDTO { get; set; }
    }
}