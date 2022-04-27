using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class User_RolesController : Controller
    {
        private LearningContext _context;
        public User_RolesController()
        {
            _context = new LearningContext();
        }

        // GET: User_Roles
       /* [Authorize(Roles="Adminstrator")]*/
        public ActionResult Index()
        {
            var user_roles = _context.User_Roles.ToList();
            return View(user_roles);
        }

        public ActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult Create(User_Role user_roles)
        {
            _context.User_Roles.Add(user_roles);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var user_roles = _context.User_Roles.SingleOrDefault(c => c.Id == id);

            if (user_roles == null)
                return HttpNotFound();

            _context.User_Roles.Remove(user_roles);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            return View("Create", course);
        }



        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                _context.Dispose();
            }
            base.Dispose(Disposing);
        }
    }
}