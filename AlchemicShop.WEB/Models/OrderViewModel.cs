using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlchemicShop.BLL.DTO;

namespace AlchemicShop.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public UserViewModel User { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }
    }
}