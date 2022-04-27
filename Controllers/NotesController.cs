using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Learning.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        private LearningContext _context;

        public NotesController()
        {
            _context = new LearningContext();
        }
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {

            var Vm = new NotesViewModel();
            Vm.NotesIndex = _context.Notes.ToList();
            Vm.NotesCreate = new Notes();
            ViewBag.TopicDD = new SelectList(_context.Topics, "Id", "Name");
            return View(Vm);
        }


        public ActionResult Create()
        {
            ViewBag.TopicDD = new SelectList(_context.Topics, "Id", "Name");

            return View(new Notes { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Notes _notes)
        {
            if (!ModelState.IsValid)
                return View("Create", _notes);

            if (_notes.Id > 0)
                _context.Entry(_notes).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Notes.Add(_notes);
                _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var notes = _context.Notes.SingleOrDefault(c => c.Id == id);

            if (notes == null)
                return HttpNotFound();

            _context.Notes.Remove(notes);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var notes = _context.Notes.SingleOrDefault(c => c.Id == id);

            if (notes == null)
                return HttpNotFound();

            return View("Create", notes);
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