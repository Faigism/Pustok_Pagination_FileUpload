using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                sliders = _context.Sliders.OrderBy(x=>x.Order).ToList(),
                features = _context.Features.Take(4).ToList(),
                featuredBooks = _context.Books
                                        .Include(x=>x.Authors).Include(x=>x.BookImages.Where(x=>x.PosterStatus!=null))
                                        .Where(x=>x.IsFeatured).Take(20).ToList(),
                newBooks = _context.Books
                                        .Include(x => x.Authors).Include(x => x.BookImages.Where(x => x.PosterStatus != null))
                                        .Where(x => x.IsNew).Take(20).ToList(),
                discountBooks = _context.Books
                                        .Include(x => x.Authors).Include(x => x.BookImages.Where(x => x.PosterStatus != null))
                                        .Where(x => x.DiscountPercent>0).Take(20).ToList(),
            };
            return View(model);
        }
    }
}
