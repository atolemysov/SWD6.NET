using System;
using System.ComponentModel.DataAnnotations;

namespace courseProject.Utilities
{
    //Custom attribute validation
    public class ValidLengthClass : ValidationAttribute
    {
        
        private readonly string v;
        public ValidLengthClass(string v, string ErrorMessage)
        {
            this.v = v;
            this.ErrorMessage = ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            return value.Equals(v);
        }
    }
}
