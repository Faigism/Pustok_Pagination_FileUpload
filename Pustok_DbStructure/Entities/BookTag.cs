using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_DbStructure.Entities
{
    public class BookTag
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
        public Book Book { get; set; }
        public Tag Tag { get; set; }
    }
}
