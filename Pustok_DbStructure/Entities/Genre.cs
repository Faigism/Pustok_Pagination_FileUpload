using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="20 -den uzun ola bilmez!")]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
