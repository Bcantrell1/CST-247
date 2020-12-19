using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //Search for a Verse
        [HttpPost]
        public ActionResult Search(VerseModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            VerseService service = new VerseService(model);
            List<string> text = service.SearchVerses();
            return View("Results", text);
        }
    }
}