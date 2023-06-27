using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.Attributes.CustomValidationAttributes
{
    public class AllowedContentTypesAttribute:ValidationAttribute
    {
        private readonly string[] _types;

        public AllowedContentTypesAttribute(params string[] types)
        {
            _types = types;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is IFormFile file)
            {
                if (_types.Contains(file.ContentType))
                    return new ValidationResult($"File düzgün formatda deyil.Ancaq ({string.Join(',', _types)})");
            }
            else if(value is List<IFormFile> list){
                foreach (var item in list)
                {
                    if (_types.Contains(item.ContentType))
                        return new ValidationResult($"File düzgün formatda deyil.Ancaq ({string.Join(',', _types)})");
                }
            }
            return ValidationResult.Success;
        }
    }
}
