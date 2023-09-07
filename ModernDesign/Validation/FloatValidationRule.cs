using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModernDesign.Validation
{
    public class FloatValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (float.TryParse(value.ToString(), out float val))  //Checks if value is a float
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Entry is invalid");

        }
    }
}
