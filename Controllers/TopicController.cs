using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class TopicController : Controller
    {

        private LearningContext _context;

        public TopicController()
        {
            _context = new LearningContext();
        }
        // GET: Topic
       /* [Authorize(Roles ="Teacher")]*/
        public ActionResult Index()
        {
            var Vm = new TopicViewModel();
            Vm.TopicIndex = _context.Topics.ToList();
            Vm.TopicCreate = new Topic();
            ViewBag.CourseDD = new SelectList(_context.Courses, "Id", "Name");
            return View(Vm);
            
        }

        public ActionResult Create()
        {
            ViewBag.CourseDD = new SelectList(_context.Courses, "Id", "Name");

            return View(new Topic { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Topic _topic)
        {
            if (!ModelState.IsValid)
                return View("Create", _topic);

            if (_topic.Id > 0)
                _context.Entry(_topic).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Topics.Add(_topic);
                _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var topic = _context.Topics.SingleOrDefault(c => c.Id == id);

            if (topic == null)
                return HttpNotFound();

            _context.Topics.Remove(topic);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var topic = _context.Topics.SingleOrDefault(c => c.Id == id);

            if (topic == null)
                return HttpNotFound();

            return View("Create", topic);
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


