using Microsoft.AspNetCore.Identity;

namespace bileton.Models
{
    public class AppUser :IdentityUser
    {
        public string Fullname { get; set; }
    }
}
