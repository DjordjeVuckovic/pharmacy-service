using System;
using System.Globalization;
using System.Windows.Controls;

namespace TechHealth.ValidationRules
{
    public class VacationValidationFinishDateRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (!DateTime.TryParse((value ?? "").ToString(),
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                    out time)) return new ValidationResult(false, "Invalid date");

            return time.Date < DateTime.Now.Date.AddDays(3)
                ? new ValidationResult(false, "Three days from today required")
                : ValidationResult.ValidResult;
        }
        
    }
}