using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Entities;
using Pustok_DbStructure.ViewModels;

namespace Pustok_DbStructure.Controllers
{
    public class BookController:Controller
    {
        private readonly PustokDb_Contex _contex;

        public BookController(PustokDb_Contex contex)
        {
            _contex = contex;
        }
        
        public IActionResult AddToBasket(int id)
        {
            var basketStr = HttpContext.Request.Cookies["basket"];
            List<BasketCookieItem_VM> cookieitems = null;
            if (basketStr == null)
                cookieitems = new List<BasketCookieItem_VM>();
            else
                cookieitems = JsonConvert.DeserializeObject<List<BasketCookieItem_VM>>(basketStr);
            BasketCookieItem_VM cookieitem = cookieitems.FirstOrDefault(x => x.BookId == id);
            if (cookieitem == null)
            {
                cookieitem = new BasketCookieItem_VM
                {
                    BookId = id,
                    Count = 1
                };
                cookieitems.Add(cookieitem);
            }
            else
            {
                cookieitem.Count++;
            }
            HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(cookieitems));
            Basket_VM basketVM = new Basket_VM();
            foreach (var ci in cookieitems)
            {
                BasketItem_VM item = new BasketItem_VM
                {
                    Count = ci.Count,
                    Book = _contex.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == ci.BookId)
                };
                basketVM.Items.Add(item);
                basketVM.TotalAmount += ((item.Book.DiscountPercent > 0 ? (item.Book.SalePrice * (100 - item.Book.DiscountPercent) / 100) : item.Book.SalePrice) * item.Count);
            }
            return PartialView("_BasketPartial", basketVM);
        }
        public IActionResult ShowBasket()
        {
            var dataStr = Request.Cookies["basket"];
            var data = JsonConvert.DeserializeObject<List<BasketCookieItem_VM>>(dataStr);
            return Json(data);
        }
        public IActionResult RemoveToBasket(int id)
        {
            var basketCookie = Request.Cookies["basket"];
            var basketData = JsonConvert.DeserializeObject<List<BasketCookieItem_VM>>(basketCookie);

            var itemToRemove = basketData.FirstOrDefault(x => x.BookId == id);
            basketData.Remove(itemToRemove);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketData));

            Basket_VM basketItems = new Basket_VM();
            foreach (var item in basketData)
            {
                BasketItem_VM basketItem = new BasketItem_VM
                {
                    Count = item.Count,
                    Book = _contex.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == id)
                };
                
                basketItems.Items.Add(basketItem);
            }

            return PartialView("_BasketPartial", basketItems);
        }
    }
}
