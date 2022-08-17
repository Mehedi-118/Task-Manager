using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Updated_Task_Manager.Data;
using Updated_Task_Manager.Models;
using Updated_Task_Manager.ViewModels;

namespace Updated_Task_Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly ToDoDbContext db;

        public AccountController(ToDoDbContext _db)
        {
            db = _db;
        }
        public IActionResult LogIn()
        {
            if (HttpContext.Session.GetString("userName") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(LoginVM model)
        {
            var isCorrect = db.Users.Any(e => e.Email == model.Email && e.Password == model.Password);
            if (isCorrect)
            {

                var users = db.Users.Select(u => new { u.Id, u.Name });
                var id = users.Select(u => u.Id).ToList();
                var name =users.Select(u => u.Name).ToList();
                HttpContext.Session.SetInt32("userId", id[0]);
                HttpContext.Session.SetString("userName", name[0]);
                TempData["userName"] = HttpContext.Session.GetString("userName");

                return RedirectToAction("Index", "Home");
            }
            else
                TempData["WrongCredentials"] = "Wrong Credentials Try Again";
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                var email = db.Users.FirstOrDefault(e => e.Email == model.Email);
                if (email != null)
                {
                    TempData["DuplicateEmail"] = "Email Already Exits Try another one";
                }
                else
                {
                    var newUser = new User()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password

                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    TempData["RegisterNewUser"] = "Email Registered Successfully";
                    return RedirectToAction("LogIn");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            var s = HttpContext.Session.GetString("userName");
            if (HttpContext.Session.GetString("userName") != null)
                HttpContext.Session.Clear();
            var p = HttpContext.Session.GetString("userName");
            return RedirectToAction("LogIn","Account");
        }
    }
}
