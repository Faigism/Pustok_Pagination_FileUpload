using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Controllers
{
    public class BookController:Controller
    {
        private readonly PustokDb_Contex _contex;

        public BookController(PustokDb_Contex contex)
        {
            _contex = contex;
        }
        public IActionResult GetDetail(int id)
        {
            Book book = _contex.Books.Include(x=>x.BookImages)
                .Include(x=>x.Genres)
                .Include(x=>x.Authors)
                .Include(x=>x.BookTags).ThenInclude(x=>x.Tag)
                .FirstOrDefault(x=>x.Id == id);
            //return Json(book);
            return PartialView("_BookModalPartial",book);
        }
    }
}
