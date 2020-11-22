using Activity1_3.Models;
using Activity1_3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }
        
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (!ModelState.IsValid) return View("Login");
            SecurityService ss = new SecurityService();
            Boolean success = ss.Authenticate(user);

            if (success)
            {
                return View("LoginPassed", user);
            }
            else
            {
                return View("LoginFailed");
            }
        }
    }
}