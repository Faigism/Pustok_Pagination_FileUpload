namespace Pustok_DbStructure.Entities
{
    public class BookTags
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
        public Books Book { get; set; }
        public Tags Tag { get; set; }
    }
}
