using bileton.Areas.Manage.ViewModels;
using bileton.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bileton.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLogin)
        {
            AppUser appUser = await _userManager.FindByNameAsync(adminLogin.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", "username and pasword error");
                return View();
            }

            var result = await  _signInManager.PasswordSignInAsync(appUser, adminLogin.Pasword, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username and pasword error");
                return View();  
            }


            return RedirectToAction("index" , "dashboard");
        }
    }
}
