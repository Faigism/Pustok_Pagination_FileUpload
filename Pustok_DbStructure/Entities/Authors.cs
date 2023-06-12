namespace Pustok_DbStructure.Entities
{
    public class Authors
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
