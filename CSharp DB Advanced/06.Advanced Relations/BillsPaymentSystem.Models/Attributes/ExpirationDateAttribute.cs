using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
                                  // value is the value of the targetted property,e.g. ExpirationDate
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentDateTime = DateTime.Now;
            var targetDateTime = (DateTime)value;

            if (currentDateTime > targetDateTime)
            {
                return new ValidationResult("Your creditCard has expired!");
            }

            return ValidationResult.Success;
        }
    }
}
