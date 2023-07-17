using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.Areas.Manage.ViewModels;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;
using Pustok_DbStructure.Helpers;
using System.Data;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
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
            return View(PaginatedList<Slider>.Create(query, page, 2));
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
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            if (slider == null)
            {
                return View("error");
            }
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Slider slider)
        {
            Slider existSlider = await _context.Sliders.FirstOrDefaultAsync();
            if (!ModelState.IsValid) return View(existSlider);
            if (existSlider == null)
            {
                return View("error");
            }
            string removeableImageName = null;
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "ImageFile must be .jpg,.jpeg or .png");
                    return View(slider);
                }
                removeableImageName = existSlider.ImageName;
                existSlider.ImageName = FileManager.Save(slider.ImageFile, _env.WebRootPath, "manage/uploads/sliders");
            }

            existSlider.Name1 = slider.Name1;
            existSlider.Name2 = slider.Name2;
            existSlider.BtnText = slider.BtnText;
            existSlider.BtnUrl = slider.BtnUrl;
            existSlider.Txt = slider.Txt;
            existSlider.Order = slider.Order;

            _context.SaveChanges();
            if (removeableImageName != null) FileManager.Delete(_env.WebRootPath, "manage/uploads/sliders", removeableImageName);

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            if (slider == null) return View("error");
            if (_context.Books.Any(x => x.Id == id)) return StatusCode(400);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
