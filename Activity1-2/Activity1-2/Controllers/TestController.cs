using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public String Index()
        {
            return @"<b>Hello World as a string from Index</b>";
        }
        //GET: /Test/TestView
        public ActionResult TestView()
        {
            return View();
        }

        //GET: /Test/ErrorMessage
        public ActionResult ErrorMessage()
        {
            return View();
        }  

        public String Play()
        {
            return "<b>Hello World as a string from Play</b>";
        }
    }
}