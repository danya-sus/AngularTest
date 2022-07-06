using System.ComponentModel.DataAnnotations;

namespace AngularTest.Filters
{
    public class PatternFilterAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Ticket number pattern invalid.";

        public PatternFilterAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stroke = (string)value;

            foreach (var symbol in stroke)
            {
                if (!char.IsNumber(symbol) && !char.IsLetter(symbol))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
    }
}
