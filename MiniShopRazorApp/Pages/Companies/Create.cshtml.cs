using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazorApp.Data;
using MiniShopRazorApp.Models;

namespace MiniShopRazorApp.Pages.Companies
{
    public class CreateModel(ApplicationDbContext _db) : PageModel
    {   
        [BindProperty]
        public Company company { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {

            _db.Companies.Add(company);
            _db.SaveChanges();
            return RedirectToPage("index");

        }
    }
}
