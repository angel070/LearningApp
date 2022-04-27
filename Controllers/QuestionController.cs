using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class QuestionController : Controller
    {
        private LearningContext _context;

        public QuestionController()
        {
            _context = new LearningContext();
        }

        public ActionResult Quest()
        {
            var Quest1 = _context.Questions.ToList();
            return View(Quest1);
        }
        // GET: Question
        public ActionResult Index()
        {
            ViewBag.TopicDD = new SelectList(_context.Topics.ToList(), "Id", "Name");
            var Quest = _context.Questions.ToList();
            return View(Quest);
        }


        public ActionResult Create()
        {
            ViewBag.TopicDD = new SelectList(_context.Topics.ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public JsonResult Create(QuestionOptionsViewModel vm)
        {
            try
            {
                var quest = new Question();
                quest.Quest = vm.Question;
                quest.Reason = vm.Reason;
                quest.TopicId = vm.TopicId;
                _context.Questions.Add(quest);
                _context.SaveChanges();
                 
                var LatestQId = quest.Id;

                var objOption = new Option();

                foreach (var item in vm.ListOfOptions)
                {
                    objOption.Opt = item;
                    objOption.QuestionId = LatestQId;
                    _context.Options.Add(objOption);
                    _context.SaveChanges();
                }
               


                var Ans = new Answer();
                Ans.Ans = vm.AnswerText;
                Ans.QuestionId = LatestQId;
                _context.Answers.Add(Ans);
                _context.SaveChanges();




                return Json(data: new { message = $"Data Added Successfully", success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(data: new { message = ex.Message + ex.StackTrace, success = false }, JsonRequestBehavior.AllowGet);
            }

            //return Json(vm.AnswerText);

        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var quest = _context.Questions.SingleOrDefault(c => c.Id == id);

            if (quest == null)
                return HttpNotFound();

            _context.Questions.Remove(quest);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}