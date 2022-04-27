using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Migrations
{
    public class QuizController : Controller
    {
        private LearningContext _context;

        public QuizController(){
            _context = new LearningContext();

    }

        // GET: Quiz
        public ActionResult Index()
        {
            /*  var Vm = new QuizViewModel();
              Vm.QuizIndex = _context.Quizes.ToList();
              Vm.QuizCreate = new Quiz();
              return View(Vm);*/

            ViewBag.QuestionDD = new SelectList(_context.Questions.ToList(), "Id", "Quest");
            var quiz = _context.Quizes.ToList();
            return View(quiz);
        }

        public ActionResult Create()
        {

            ViewBag.QuestionDD = new SelectList(_context.Questions.ToList(), "Id", "Quest");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Quiz _quiz)
        {
            if (!ModelState.IsValid)
                return View("Create", _quiz);

            if (_quiz.Id > 0)
                _context.Entry(_quiz).State = System.Data.Entity.EntityState.Modified;
            else
            _context.Quizes.Add(_quiz);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult Qui()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Qui(int ? id, Quiz _quiz)
        {
            //var quiz = _context.Quizes.Where(c => c.Id == id).Select();
            return View();
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var quiz = _context.Quizes.SingleOrDefault(c => c.Id == id);

            if (quiz== null)
                return HttpNotFound();

            _context.Quizes.Remove(quiz);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var quiz = _context.Quizes.SingleOrDefault(c => c.Id == id);

            if (quiz == null)
                return HttpNotFound();

            return View("Create", quiz);
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