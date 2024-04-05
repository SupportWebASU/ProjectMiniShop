using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazorApp.Data;
using MiniShopRazorApp.Models;

namespace MiniShopRazorApp.Pages.Companies
{
    public class EditModel(ApplicationDbContext _db) : PageModel
    {
        
        [BindProperty]
        public Company company { get; set; }
        public void OnGet(int id)
        {
            if (id != null &&id !=0)
                company = _db.Companies.SingleOrDefault(c => c.Id == id);
        
        }
        public IActionResult OnPost()
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }


    }
}
