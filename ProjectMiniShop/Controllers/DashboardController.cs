using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Controllers
{
    public class DashboardController : Controller
    {
        private static List<Company> _company=new List<Company>();
        private static List<Product> _products = new List<Product>();
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _company.Add(new Company { Id=1,Name="Niki" });
            _company.Add(new Company { Id=2,Name="adidas" });
            _db = db;

        }
        public IActionResult Index()
        {

            return View();
        }
        #region addProduct
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("GetProduct");
        }
        #endregion
        #region GetProduct
        public IActionResult GetProduct()
        {
            var product = _db.Products.Include(p => p.Company).ToList();
            return View(product);
        }

        #endregion
        #region Remove
        
        public IActionResult DeleteProduct(int id)
        {
            Product? product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return RedirectToAction("GetProduct");
            }
            return RedirectToAction("GetProduct");
        }
        #endregion
        #region EditProduct
        public IActionResult EditProduct(int? id)
        {
            Product? product = _db.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Product? product = _db.Products.SingleOrDefault(p => p.Id == model.Id);
            product.EnableSize = model.EnableSize;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Name = model.Name;
            product.CompanyId = model.CompanyId;
            product.Quantity = model.Quantity;
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("GetProduct");
        }
        #endregion
    }
}
