using System;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public StatusViewModel Status { get; set; }

    }
}