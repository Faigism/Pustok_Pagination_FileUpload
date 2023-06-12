namespace Pustok_DbStructure.Entities
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookTags> BookTags { get; set; }
    }
}
