using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace courseProject.Utilities
{
    //Custom attribute validation
    public class ValidLengthClass : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                String v = value.ToString();
                if ((v.Any(char.IsLetter) && v.Any(char.IsDigit))||(v.Any(char.IsLetter)))
                    return ValidationResult.Success;
            }
            return new ValidationResult("Login must be only with characters!");
        }
    }
}
