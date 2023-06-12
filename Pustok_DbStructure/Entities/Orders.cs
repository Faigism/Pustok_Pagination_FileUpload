namespace Pustok_DbStructure.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
