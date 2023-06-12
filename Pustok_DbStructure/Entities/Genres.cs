namespace Pustok_DbStructure.Entities
{
    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
