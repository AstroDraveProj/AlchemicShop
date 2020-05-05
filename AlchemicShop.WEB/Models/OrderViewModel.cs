using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please, enter scheduled delivery date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'mm'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SheduledDate { get; set; }

        [Required(ErrorMessage = "Please, enter date of delivery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'mm'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ClosedDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public UserViewModel Customer { get; set; }

        public ICollection<OrderProductViewModel> OrderProductViewModel { get; set; }
    }
}