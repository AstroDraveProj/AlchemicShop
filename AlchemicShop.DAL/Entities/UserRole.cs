using System.Collections.Generic;

namespace AlchemicShop.DAL.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
