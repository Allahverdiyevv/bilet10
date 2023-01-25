using bileton.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bileton.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;


        }

        public IActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.ToList();
            return View(teams);
        }

   
    }
}