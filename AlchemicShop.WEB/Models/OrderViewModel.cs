using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please, enter date of delivery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SheduledDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public UserViewModel User { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }
    }
}