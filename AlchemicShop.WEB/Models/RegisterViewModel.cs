using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please, enter name of user")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter name of user")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, enter name of user")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name is incorrect (a-zA-Z)")]
        public string Password { get; set; }
    }
}