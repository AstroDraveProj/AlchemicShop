using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class LoginViewModel
    {
        [Required, MaxLength(20)]
        public string Login { get; set; }

        [Required, MaxLength(40)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}