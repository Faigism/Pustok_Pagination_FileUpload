using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.Areas.Manage.ViewModels;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly PustokDb_Contex _context;

        public GenreController(PustokDb_Contex context)
        {
            _context = context;
        }
        /*public IActionResult Index(int page = 1, string search = null)
        {
            ViewBag.Search = search;
            //if(search == null)
            //{
            //    var vm = new PaginatedList<Genre>
            //    {
            //        Items = _context.Genres.Include(x => x.Books).Skip((page - 1) * 2).Take(2).ToList(),
            //        PageIndex = page,
            //        TotalPages = (int)Math.Ceiling(_context.Genres.Count() / 2d)
            //    };
            //    return View(vm);
            //}
            //else
            //{
            //    var vm = new PaginatedList<Genre>
            //    {
            //        Items = _context.Genres.Include(x => x.Books).Where(x=>x.Name.Contains(search)).Skip((page - 1) * 2).Take(2).ToList(),
            //        PageIndex = page,
            //        TotalPages = (int)Math.Ceiling(_context.Genres.Where(x => x.Name.Contains(search)).Count() / 2d)
            //    };
            //    return View(vm);
            //}
            //daha sade formada asagidaki kimi yaza bilerik:
            var query = _context.Genres.Include(x => x.Books).AsQueryable();
            if (search != null)
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            
            return View(PaginatedList<Genre>.Create(query, page, 2));
        }
        */
        public IActionResult Index(int page = 1, string search = null)
        {
            ViewBag.Search = search;
            var query = _context.Genres.Include(x => x.Books).AsQueryable();
            if (search != null) query = query.Where(x => x.Name.Contains(search));

            return View(PaginatedList<Genre>.Create(query,page,3));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
                return View();
            if (_context.Genres.Any(x => x.Name == genre.Name.Trim()))
            {
                ModelState.AddModelError("Name", "Ad artıq mövcuddur!..");
                return View();
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.Find(id);
            if (genre == null)
            {
                return View("error");
            }
            return View(genre);
        }
        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid)
                return View();
            Genre existGenre = _context.Genres.Find(genre.Id);
            if (existGenre == null)
            {
                return View("error");
            }
            if (genre.Name != existGenre.Name && _context.Genres.Any(x => x.Name == genre.Name.Trim()))
            {
                ModelState.AddModelError("Name", "Genre artıq mövcuddur!..");
                return View();
            }

            existGenre.Name = genre.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
