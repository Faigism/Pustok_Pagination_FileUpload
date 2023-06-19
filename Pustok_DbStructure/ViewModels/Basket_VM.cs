namespace Pustok_DbStructure.ViewModels
{
    public class Basket_VM
    {
        public List<BasketItem_VM> Items { get; set; } = new List<BasketItem_VM>();
        public decimal TotalAmount { get; set; }
    }
}
