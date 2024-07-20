using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TEST_DEV_API.ValidationAttributes
{
    public class RfcAttribute : ValidationAttribute
    {
        private static readonly Regex RfcRegex = new Regex(@"^[A-ZÑ&]{3,4}\d{6}[A-Z0-9]{3}$", RegexOptions.Compiled);

        public RfcAttribute() : base("Invalid RFC format.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("RFC is required.");
            }

            var rfc = value.ToString();
            if (!RfcRegex.IsMatch(rfc))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
