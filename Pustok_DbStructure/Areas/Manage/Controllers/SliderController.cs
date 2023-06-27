using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.Areas.Manage.ViewModels;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;
using Pustok_DbStructure.Helpers;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController:Controller
    {
        private readonly PustokDb_Contex _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(PustokDb_Contex context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Sliders.AsQueryable();
            return View(PaginatedList<Slider>.Create(query,page,2));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider == null || slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile boş ola bilməz..");
                return View(slider);
            }
            if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Imagefile yalnız 'jpeg', 'png' formatında ola bilər..");
                return View(slider);
            }
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            slider.ImageName = FileManager.Save(slider.ImageFile,_env.WebRootPath,"manage/uploads/sliders");
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
