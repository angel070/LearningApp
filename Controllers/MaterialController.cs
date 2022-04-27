using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class MaterialController : Controller
    {


        private LearningContext _context;

        public MaterialController()
        {
            _context = new LearningContext();
        }
        public ActionResult Create()
        {
            ViewBag.TopicDD = new SelectList(_context.Topics, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Material material, HttpPostedFileBase picture)
        {
            //File Name
            string imageName = (picture == null) ? null : System.IO.Path.GetFileName(picture.FileName);

            //image path
            string imagePath = "~/Upload/Material/" + imageName;
            //Save image into server location
            picture.SaveAs(Server.MapPath(imagePath));

            material.FileName = imageName;
            material.FilePath = imagePath;

            _context.Materials.Add(material);
            _context.SaveChanges();
            return Content("saved successfully");
        }

        // GET: Material
      
        public ActionResult Index()
        {
            var material = _context.Materials.ToList();
            return View(material);
        }
    }
}