using System;
using System.Globalization;
using System.Windows.Controls;

namespace TechHealth.ValidationRules
{
    public class VacationValidationStartDateRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (!DateTime.TryParse((value ?? "").ToString(),
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                    out time)) return new ValidationResult(false, "Invalid date");

            return time.Date < DateTime.Now.Date.AddDays(2)
                ? new ValidationResult(false, "Two days from today required")
                : ValidationResult.ValidResult;
        }
    }
}