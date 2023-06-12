namespace Pustok_DbStructure.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte Discount { get; set; }
    }
}
