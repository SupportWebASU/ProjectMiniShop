using Microsoft.AspNetCore.Mvc;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Controllers
{
    public class DashboardController : Controller
    {
        private static List<Company> _company=new List<Company>();
        private static List<Product> _products = new List<Product>();
        public DashboardController()
        {
            _company.Add(new Company { Id=1,Name="Niki" });
            _company.Add(new Company { Id=2,Name="adidas" });
            

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
            Company company = _company.FirstOrDefault(m=>m.Id==product.Company.Id);
            if (_products.Count() != 0)
            {
                int id = _products.Max(m => m.Id) + 1;
                product.Id = id;

            }
            else
            {
                product.Id = 1;

            }
            product.Company = company;
            _products.Add(product);
            return View();
        }
        #endregion
        #region GetProduct
        public IActionResult GetProduct()
        {
            return View(_products);
        }

        #endregion
        #region Remove
        
        public IActionResult DeleteProduct(int id)
        {
            Product product=_products.SingleOrDefault(m=>m.Id==id);
            
            _products.Remove(product);
            return RedirectToAction("GetProduct");
        }
        #endregion
        #region EditProduct
        public IActionResult EditProduct(int id)
        {
            Product product= _products.SingleOrDefault(p=>p.Id==id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            Product product = _products.SingleOrDefault(p => p.Id == model.Id);
            product.EnableSize= model.EnableSize;
            product.Price= model.Price;
            product.Description= model.Description;
            product.Name= model.Name;
            product.Company= _company.FirstOrDefault(m=>m.Id==model.Company.Id);
            product.Quantity= model.Quantity;
            return RedirectToAction("GetProduct");
        }
        #endregion
    }
}
