using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please, enter name of user")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter login of user")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}