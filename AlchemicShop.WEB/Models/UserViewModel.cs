﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Login { get; set; }

        [Required, MaxLength(40)]
        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<OrderViewModel> OrdersDTO { get; set; }
    }
}