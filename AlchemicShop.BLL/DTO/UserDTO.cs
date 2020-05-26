using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<OrderDTO> OrdersDTO { get; set; }
    }
}
