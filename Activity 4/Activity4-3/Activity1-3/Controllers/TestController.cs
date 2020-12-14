using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [CustomAuthorization]
        public ActionResult Index()
        {
            return Content("This is the Test Controller. It should be protected content because of the custom authorization attribute.");
        }

        [HttpGet]
        public ActionResult LessSecureMethod()
        {
            return Content("Slightly less protected content.");
        }
    }
}