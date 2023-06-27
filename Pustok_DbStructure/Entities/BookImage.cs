using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_DbStructure.Entities
{
    public class BookImage
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }
        public bool? PosterStatus { get; set; }
        
    }
}
