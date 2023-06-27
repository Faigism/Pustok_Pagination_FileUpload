using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.Attributes.CustomValidationAttributes
{
    public class MaxFileLengthAttribute:ValidationAttribute
    {
        private readonly int _maxLength;
        public MaxFileLengthAttribute(int maxLength)
        {
            _maxLength= maxLength;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is IFormFile)
            {
                var file = (IFormFile)value;
                if (file.Length > _maxLength)
                    return new ValidationResult($"File uzunluğu {_maxLength/1024/1024}MB -dan böyük ola bilməz");
            }
            return ValidationResult.Success;
        }
    }
}
