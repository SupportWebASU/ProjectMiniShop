using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db) : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Product>> getProduct()
        {
            var products = _db.Products.Include(m => m.Company).ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> getProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.Company).SingleOrDefault(m=>m.Id==id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.Company).
                SingleOrDefault(m => m.Id == id);
            if (products == null)
                return NotFound();
            _db.Products.Remove(products);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product Updatedproduct)
        {
            if (Updatedproduct.Id <= 0 && !ModelState.IsValid)
            {
                return BadRequest();
                
            }
            var product=_db.Products.Include(m => m.Company).FirstOrDefault(m=>m.Id== Updatedproduct.Id);
            if (product == null)
                return NotFound();
            product.Name = Updatedproduct.Name;
            product.Description = Updatedproduct.Description;
            product.Price = Updatedproduct.Price;
            product.EnableSize = Updatedproduct.EnableSize;
            product.CompanyId = Updatedproduct.CompanyId;
            _db.SaveChanges();
            return Ok();
        }
    }
}
