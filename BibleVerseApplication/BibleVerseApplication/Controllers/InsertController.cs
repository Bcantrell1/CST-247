using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class InsertController : Controller
    {
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(VerseModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "This verse was already added previously!";
                return View("Index");
            }

            VerseService service = new VerseService(model);
            service.InsertVerse();
            ViewBag.Message = "You have added: " + model.Book + " " + model.Chapter + ":" + model.Verse + " to the app!";
            return View("Index");
        }
    }
}