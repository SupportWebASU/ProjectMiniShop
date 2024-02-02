using Microsoft.AspNetCore.Mvc;

namespace ProjectMiniShop.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
