using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ModernDesign.Validation
{
    public class StockNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(Regex.IsMatch(value.ToString(), "^[a-zA-Z]+$"))  //Checks if the string only contains letters
            {
                return ValidationResult.ValidResult;
            }
            
            return new ValidationResult(false, "Name is invalid");
            
        }
    }
}
