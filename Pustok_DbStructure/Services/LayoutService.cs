using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.ViewModels;

namespace Pustok_DbStructure.Services
{
    public class LayoutService
    {
        private readonly PustokDb_Contex _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(PustokDb_Contex context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public Basket_VM GetBasket()
        {
            
            var basketStr = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketCookieItem_VM> cookieItems = null;
            if(basketStr == null)
            {
                cookieItems = new List<BasketCookieItem_VM>();
            }
            else
            {
                cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItem_VM>>(basketStr);
            }
            var basketVM = new Basket_VM();
            basketVM.Items = new List<BasketItem_VM>();
            foreach (var ci in cookieItems)
            {
                BasketItem_VM item = new BasketItem_VM
                {
                    Count = ci.Count,
                    Book = _context.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == ci.BookId)
                };
                basketVM.Items.Add(item);
                basketVM.TotalAmount += ((item.Book.DiscountPercent > 0 ? (item.Book.SalePrice * (100 - item.Book.DiscountPercent) / 100) : item.Book.SalePrice)*item.Count);
            }
            return basketVM;
        }

    }
}
