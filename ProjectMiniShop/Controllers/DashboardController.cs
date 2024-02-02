using Microsoft.AspNetCore.Mvc;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Controllers
{
    public class DashboardController : Controller
    {
        private static List<Company> _company=new List<Company>();
        private static List<Product> _products;
        public DashboardController()
        {
            _company.Add(new Company { Id=1,Name="Niki" });
            _company.Add(new Company { Id=2,Name="adidas" });
            _products=new List<Product>();

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
            product.Company = company;
            _products.Add(product);
            return View();
        }
        #endregion
    }
}
