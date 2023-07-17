using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Pustok_DbStructure.Areas.Manage.Controllers
{
    [Authorize(Roles ="Admin, SuperAdmin")]
    [Area("manage")]
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
