using Learning.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning.Config;
using System.Net;

namespace Learning.Controllers
{
    public class HomeController : Controller
    {

        private LearningContext _context;

        public HomeController()
        {  
            _context = new LearningContext();
        }
       
        public ActionResult Index()
        {
            var Vm = new ProgrammeViewModel();
            Vm.ProgrammeIndex = _context.Programmes.ToList();
            Vm.ProgrammeCreate = new Programme();
            
            return View(Vm);
        }

        public ActionResult createProgramme()
        {

         return View(new Programme { Id = 0 });
        } 

        [HttpPost]
        public ActionResult createProgramme(Programme _programme )
        {
            if (!ModelState.IsValid)
                return View("createProgramme", _programme);


            if (_programme.Id > 0)
                _context.Entry(_programme).State = System.Data.Entity.EntityState.Modified;
            else

                _context.Programmes.Add(_programme);
                _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var programme = _context.Programmes.SingleOrDefault(c => c.Id == id);

            if (programme == null)
                return HttpNotFound();
            _context.Programmes.Remove(programme);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var programme = _context.Programmes.SingleOrDefault(c => c.Id == id);

            if (programme == null)
                return HttpNotFound();
            

            return View("createProgramme", programme);
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