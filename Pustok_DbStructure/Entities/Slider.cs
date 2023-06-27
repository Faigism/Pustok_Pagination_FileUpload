using Pustok_DbStructure.Attributes.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_DbStructure.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }
        [MaxLength(50)]
        public string Name1 { get; set; }
        [MaxLength(50)]
        public string Name2 { get; set; }
        [MaxLength(150)]
        public string Txt { get; set; }
        [MaxLength(150)]
        public string BtnText { get; set; }
        [MaxLength(150)]
        public string BtnUrl { get; set; }
        [NotMapped]
        [MaxFileLength(2097152)]
        public IFormFile ImageFile { get; set; }
    }
}
