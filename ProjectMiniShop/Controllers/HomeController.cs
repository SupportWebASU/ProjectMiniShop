using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;
using System.Diagnostics;

namespace ProjectMiniShop.Controllers
{
    public class HomeController(ApplicationDbContext _db) : Controller
    {
       

     
        public IActionResult Index()
        {

            return View(_db.Products.Include(m=>m.Company).ToList());
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
