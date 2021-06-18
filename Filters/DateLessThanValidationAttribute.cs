using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Filters
{
    public class DateLessThanValidationAttribute : ValidationAttribute
    {
        public DateLessThanValidationAttribute(int years)
        {
            this.Years = years;
        }

        public int Years { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                var now = DateTime.Now;
                var pastDate = now.AddYears(-this.Years);

                if (date <= pastDate)
                {
                    return null;
                }
            }

            return new ValidationResult(this.FormatErrorMessage(this.ErrorMessage));
        }
    }
}
