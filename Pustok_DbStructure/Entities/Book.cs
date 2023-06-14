namespace Pustok_DbStructure.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StockStatus { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Description { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Author Authors { get; set; }
        public Genre Genres { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
        public ICollection<BookImage> BookImages { get; set; }
    }
}
