using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemicShop.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        [Index("IX_Login", IsUnique = true)]
        public string Login { get; set; }

        [Required, MaxLength(40)]
        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

        public virtual ICollection<Order> Orders { get; set; }         
    }
}
