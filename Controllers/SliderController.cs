using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class SliderController : Controller
    {
        private LearningContext _context;

        public SliderController()
        {
            _context = new LearningContext();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slider slider, HttpPostedFileBase picture)
        {
            //File Name
            string imageName = (picture == null) ? null : System.IO.Path.GetFileName(picture.FileName);

            //image path
            string imagePath = "~/Uploads/Slider/" + imageName;
            //Save image into server location
            picture.SaveAs(Server.MapPath(imagePath));

            slider.ImageName = imageName;
            slider.FilePath = imagePath;

            _context.sliders.Add(slider);
            _context.SaveChanges();

            return Content("image saved successfully");
        }

        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }
    }
}