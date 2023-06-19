using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController:Controller
    {
        private readonly PustokDb_Contex _context;

        public GenreController(PustokDb_Contex context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Genres.Include(x=>x.Books).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if(!ModelState.IsValid)
                return View();
            if(_context.Genres.Any(x=>x.Name== genre.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return View();
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x=>x.Id==id);
            return View(genre);
        }
        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Genre existGenre = _context.Genres.FirstOrDefault(x=>x.Id==genre.Id);
            existGenre.Name = genre.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
