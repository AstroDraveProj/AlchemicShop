using System;
using System.ComponentModel.DataAnnotations;

namespace AlchemicShop.WEB.Validation
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            return (DateTime)date >= DateTime.Today;
        }
    }
}