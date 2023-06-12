namespace Pustok_DbStructure.Entities
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StockStatus { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Description { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Authors Authors { get; set; }
        public Genres Genres { get; set; }
        public ICollection<BookTags> BookTags { get; set; }
        public ICollection<BookImages> BookImages { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
