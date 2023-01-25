using bileton.Helpers;
using bileton.Models;
using Microsoft.AspNetCore.Mvc;

namespace bileton.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _dataContext;

        public TeamController( DataContext dataContext , IWebHostEnvironment env)
        {
            _env = env;
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team == null) return NotFound();
            team.Image = FileManage.SaveFile(_env.WebRootPath, "uploads\\sliders", team.ImageFile);

            _dataContext.Teams.Add(team);
            _dataContext.SaveChanges();
            return RedirectToAction("index");

          

        }

        public IActionResult Update(int id)
        {
            Team team = _dataContext.Teams.Find(id);
            if (team == null) return NotFound();

            return View(team);

        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team teamex = _dataContext.Teams.FirstOrDefault(x=>x.Id == team.Id);
            if (teamex == null) return NotFound();
            if (team.ImageFile != null)
            {
                string name = FileManage.SaveFile(_env.WebRootPath, "uploads\\sliders", team.ImageFile);

                FileManage.DeleteFile(_env.WebRootPath, "uploads\\sliders", teamex.Image);

                teamex.Image = name;
            }

            teamex.Name = team.Name;
            teamex.Profession = team.Profession;
            teamex.Facebook = team.Facebook;
            teamex.Instagram = team.Instagram;
            teamex.Twiter = team.Twiter;

            _dataContext.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int Id)
        {

            Team teamExDLT = _dataContext.Teams.FirstOrDefault(x => x.Id == Id);
            if (teamExDLT == null) return NotFound();

            if (teamExDLT.ImageFile != null)
            {
                FileManage.DeleteFile(_env.WebRootPath, "Upload\\Teamss", teamExDLT.Image);
            }

            _dataContext.Teams.Remove(teamExDLT);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
