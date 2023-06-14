using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.ViewModels
{
    public class Pustok_VM
    {
        public List<Slider> sliders { get; set; }
        public List<Feature> features { get; set; }
        public List<Book> featuredBooks { get; set; }
        public List<Book> newBooks { get; set; }
        public List<Book> discountBooks { get; set; }
    }
}
