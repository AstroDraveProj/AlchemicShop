using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Login { get; set; }

        [Required, MaxLength(40)]
        public string Password { get; set; }

        public int UserRoleIdDTO { get; set; }

        public  UserRoleDTO UserRoleDTO { get; set; }
       
        public virtual ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
