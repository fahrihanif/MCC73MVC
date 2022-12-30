using MCC73MVC.Repositories.Data;
using MCC73MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepositories _repo;
        public AccountController(AccountRepositories repo)
        {
            _repo = repo;
        }

        //http://localhost/Login
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public IActionResult Login(LoginVM login)
        {
            var result = _repo.Login(login);
            if (result == 2)
            {
                HttpContext.Session.SetString("email", login.Email);
                HttpContext.Session.SetString("role", _repo.UserRoles(login.Email).FirstOrDefault());
                if (HttpContext.Session.GetString("role") == "Manager")
                {
                    return RedirectToAction("Index", "Department");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Login Failed";
            return View();
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public IActionResult Register(RegisterVM register)
        {
            var result = _repo.Register(register);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
