using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_DbStructure.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool StockStatus { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal CostPrice { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Author Authors { get; set; }
        public Genre Genres { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
        public ICollection<BookImage> BookImages { get; set; }
    }
}
