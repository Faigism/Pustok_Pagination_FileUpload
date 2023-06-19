using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController:Controller
    {
        private readonly PustokDb_Contex _context;

        public AuthorController(PustokDb_Contex context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.Include(x=>x.Books).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid)
            {
                if(_context.Authors.Any(x=>x.FullName == author.FullName))
                {
                    ModelState.AddModelError("Name", "Author artiq movcuddur..");
                }
                else
                {
                    _context.Authors.Add(author);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if(author == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var author2 = _context.Authors.Find(id);
            if (author2 == null)
            {
                return NotFound();
            }
            return View(author2);
        }
        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var author3 = _context.Authors.FirstOrDefault(x => x.FullName == author.FullName);
            if (author3 != null && author3.Id != author.Id)
            {
                ModelState.AddModelError("Name", "Author artiq movcuddur..");
                return View();
            }
            var updateAuthor = _context.Authors.FirstOrDefault(x => x.Id==author.Id);
            if (updateAuthor == null)
            {
                return NotFound();
            }
            updateAuthor.FullName = author.FullName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
