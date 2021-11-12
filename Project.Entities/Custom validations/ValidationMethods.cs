using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Custom_validations
{
    public class ValidationMethods
    {
        public static ValidationResult ValidateGreaterThanZero(double value, ValidationContext context)
        {
            bool isValid = true;
            if (value<=0)
            {
                isValid = false;
            }
            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format($"The field {context.MemberName} must be greater than 0"), new List<string> {context.MemberName});
            }
        }
    }
}
