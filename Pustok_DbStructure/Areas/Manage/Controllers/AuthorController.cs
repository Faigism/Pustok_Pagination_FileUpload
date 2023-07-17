using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class AuthorController : Controller
    {
        private readonly PustokDb_Contex _context;
        private readonly IWebHostEnvironment _env;

        public AuthorController(PustokDb_Contex context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            ViewBag.Search = search;
            var query = _context.Authors.Include(x => x.Books).AsQueryable();
            if (search != null) query = query.Where(x => x.FullName.Contains(search));

            return View(PaginatedList<Author>.Create(query, page, 2));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ImageFile", "Zəhmət olmasa faylı düzgün daxil edin. Fayl yalnız 'jpeg' və 'png' formatında ola bilər");
                return View();
            }

            if (author.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile boş ola bilməz..");
                return View();
            }

            if (author.ImageFile.ContentType != "image/jpeg" && author.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Imagefile yalnız 'jpeg', 'png' formatında ola bilər..");
                return View();
            }
            author.ImageName = FileManager.Save(author.ImageFile, _env.WebRootPath, "manage/uploads/authors");
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author == null)
            {
                return View("error");
            }
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            Author existAuthor = _context.Authors.Find(author.Id);
            if (existAuthor == null)
            {
                return View("error");
            }
            string removableImageName = null;
            if (author.ImageFile != null)
            {
                if (author.ImageFile.ContentType != "image/jpeg" && author.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Şəkil yalnız 'jpeg' və 'png' formatında ola bilər");
                    author.ImageName = existAuthor.ImageName;
                    return View(author);
                }
                removableImageName = existAuthor.ImageName;
                existAuthor.ImageName = FileManager.Save(author.ImageFile, _env.WebRootPath, "manage/uploads/authors");
            }
            existAuthor.FullName = author.FullName;
            _context.SaveChanges();
            if (removableImageName != null) FileManager.Delete(_env.WebRootPath, "manage/uploads/authors", removableImageName);
            return RedirectToAction("Index");
        }
    }
}
