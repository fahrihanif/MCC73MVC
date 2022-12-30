using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC73MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepositories _repo;
        private DivisionRepositories _divRepo;

        public DepartmentController(DepartmentRepositories repo, DivisionRepositories divRepo)
        {
            _repo = repo;
            _divRepo = divRepo;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Unauthorized", "Error");
            }
            else if (HttpContext.Session.GetString("role") != "Manager")
            {
                return RedirectToAction("Forbidden", "Error");
            }


            var result = _repo.Get();
            var resultDiv = _divRepo.Get();
            //foreach (var item in result)
            //{
            //    item.Division.Id = resultDiv.FirstOrDefault(i => i.Id == item.DivisionId).Id;
            //    item.Division.Name = resultDiv.FirstOrDefault(i => i.Id == item.DivisionId).Name;
            //}
            return View(result);
        }

        public IActionResult Create()
        {
            var options = GenerateViewBagOptions();
            ViewBag.DivisionId = options;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var result = _repo.Insert(department);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var result = _repo.Update(department);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var result = _repo.Delete(id);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }

        [NonAction]
        private List<SelectListItem> GenerateViewBagOptions()
        {
            var divisions = _divRepo.Get().ToList();

            List<SelectListItem> Options = new List<SelectListItem>();
            divisions.ForEach(d => Options.Add(new SelectListItem { Text = d.Name, Value = d.Id.ToString() }));
            return Options;
        }
    }
}
