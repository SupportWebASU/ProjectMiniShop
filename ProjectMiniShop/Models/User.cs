using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectMiniShop.Models
{
    public class User : IdentityUser
    {
        public string DOB { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
