using Activity1_3.Models;
using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;


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

            MyLogger.GetInstance().Info("Entering the login controller. Login Method");
            try
            {
            if (!ModelState.IsValid) return View("Login");

                SecurityService ss = new SecurityService();
                Boolean success = ss.Authenticate(user);

                if (success)
                {
                    MyLogger.GetInstance().Info("Exiting LoginController.Login() Login passed!");
                    return View("LoginPassed");
                }
                else
                {
                    MyLogger.GetInstance().Info("Exiting LoginController.Login() Login Failed!");
                    return View("LoginFailed", user);
                }
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Exception! " + e.Message);
                return Content("Exception in login" + e.Message);
            }
            
        }
    }
}