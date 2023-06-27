using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_DbStructure.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(25)]
        public string Title1 { get; set; }
        [MaxLength(50)]
        public string Title2 { get; set; }
    }
}
