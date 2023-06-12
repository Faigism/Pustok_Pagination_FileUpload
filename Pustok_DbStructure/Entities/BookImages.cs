namespace Pustok_DbStructure.Entities
{
    public class BookImages
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public bool PosterStatus { get; set; }
        public int BookId { get; set; }
    }
}
