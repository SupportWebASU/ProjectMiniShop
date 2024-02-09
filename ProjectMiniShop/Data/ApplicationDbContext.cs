using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }

    }
}
