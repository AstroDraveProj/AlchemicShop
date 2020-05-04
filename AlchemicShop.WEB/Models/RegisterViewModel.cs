using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Login { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}