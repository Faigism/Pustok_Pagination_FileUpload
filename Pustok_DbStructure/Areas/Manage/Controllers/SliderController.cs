using Microsoft.AspNetCore.Mvc;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController:Controller
    {
        private readonly PustokDb_Contex _context;

        public SliderController(PustokDb_Contex context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }
    }
}
