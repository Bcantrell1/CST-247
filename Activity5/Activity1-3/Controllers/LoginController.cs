using Activity1_3.Models;
using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger logger;
        // GET: Login
        public LoginController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            logger.Info("You are currently in the LoginController");
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            logger.Info("Starting login method.");
            SecurityService ss = new SecurityService();
            Boolean success = ss.Authenticate(user);

            if (success)
            {
                logger.Info("Login was successful.");
                return View("LoginPassed", user);
            }
            else
            {
                logger.Info("Login Failed.");
                return View("LoginFailed");
            }
        }
    }
}