using System.ComponentModel.DataAnnotations;

namespace AngularTest.Filters
{
    public class LengthFilterAttribute : ValidationAttribute
    {
        public int Length { get; }
        public string GetErrorMessage() => "Ticket number length should be 13 symbols.";

        public LengthFilterAttribute()
        {
            Length = 13;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((string)value).Length != Length)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
