using MCC73MVC.Contexts;
using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class RoleController : Controller
    {
        private RoleRepositories _repo;
        public RoleController(RoleRepositories repo)
        {
            _repo = repo;
        }

        // GET
        public IActionResult Index()
        {
            var results = _repo.Get();
            return View(results);
        }

        // GET - DETAILS
        public IActionResult Details(int key)
        {
            var results = _repo.Get(key);
            return View(results);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role role)
        {
            var result = _repo.Insert(role);
            if (result > 0)
                return RedirectToAction("Index", "Role");
            return View();
        }
    }
}
