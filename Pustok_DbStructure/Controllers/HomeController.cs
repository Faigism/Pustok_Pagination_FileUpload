using Microsoft.AspNetCore.Mvc;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;
using Pustok_DbStructure.ViewModels;
using System.Collections.Generic;

namespace Pustok_DbStructure.Controllers
{
    public class HomeController:Controller
    {
        private readonly PustokDb_Contex _context;

        public HomeController(PustokDb_Contex context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Pustok_VM model = new Pustok_VM()
            {
                sliders = _context.Slider.Take(2).ToList(),
                features = _context.Feature.Take(4).ToList(),
            };
            return View(model);
        }
    }
}
