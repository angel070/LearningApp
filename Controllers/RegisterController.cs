using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning.ViewModel;

namespace Learning.Controllers
{
    public class RegisterController : Controller
    {
        private LearningContext _context;

        public RegisterController()
        {
            _context = new LearningContext();
        }
        // GET: Register

        public ActionResult Index()
        {
            var register = _context.Registers.ToList();
            return View(register);
        }
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.User_Roles, "Id", "Role");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Register register)
        {
            _context.Registers.Add(register);
            _context.SaveChanges();
            return RedirectToAction("Login","Register");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return Content("bAD");

            var _login = _context.Registers.Where(n => n.Name == login.Username && n.Password == login.Password ).FirstOrDefault();

            if (_login == null)
            {
                ModelState.AddModelError("Username", "User name or Password is incorrect");
                return View("Login");
            }
            else
                Session["Username"] = login.Username;
            return RedirectToAction("Index","Home");

        }
    }
}