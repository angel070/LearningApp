using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class CourseController : Controller
    {

        private LearningContext _context;
         
        public CourseController()
        {
            _context = new LearningContext();
        }

        // GET: Course
        public ActionResult Index()
        {
            var Vm = new CourseViewModel();
            Vm.CourseIndex = _context.Courses.ToList();
            Vm.CourseCreate = new Course();

            ViewBag.ProgramDD = new SelectList(_context.Programmes, "Id", "Name");
            return View(Vm);
           

        }

        public ActionResult Create()
        {

            ViewBag.ProgramDD = new SelectList(_context.Programmes, "Id", "Name");

            return View(new Course { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Course _course)
        {
            if (!ModelState.IsValid)
                return View("Index", _course);

            if (_course.Id > 0)
                _context.Entry(_course).State = System.Data.Entity.EntityState.Modified;
            else
            _context.Courses.Add(_course);
            _context.SaveChanges();

    
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return HttpNotFound();

            _context.Courses.Remove(course);
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