namespace Pustok_DbStructure.Entities
{
    public class OrderItems
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal UnitCostPrice { get; set; }
        public decimal UnitDiscountPercent { get; set; }
    }
}
