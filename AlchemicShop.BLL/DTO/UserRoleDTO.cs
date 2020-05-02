using System.Collections.Generic;

namespace AlchemicShop.BLL.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
