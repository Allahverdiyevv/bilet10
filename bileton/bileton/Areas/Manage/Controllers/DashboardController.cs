using bileton.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bileton.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAdmin() 
        {
            AppUser user = new AppUser
            {

                Fullname= "Cebrayil Ibrahimov",
                UserName = "SuperAdmin"
            };
            var result =  await  _userManager.CreateAsync(user, "admin123");

            return Ok(result);
        
        }
    }
}
