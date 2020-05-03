using System.Collections.Generic;

namespace AlchemicShop.WEB.Models
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserViewModel> UserViewModel { get; set; }
    }
}