using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.ViewModels
{
    public class Pustok_VM
    {
        public ICollection<Slider> sliders { get; set; }
        public ICollection<Feature> features { get; set; }
        public ICollection<Products> products { get; set; }
    }
}
