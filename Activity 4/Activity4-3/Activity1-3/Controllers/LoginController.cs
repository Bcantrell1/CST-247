using Activity1_3.Models;
using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        [CustomAuthorization]
        public ActionResult Login(UserModel user)
        {
            MyLogger.GetInstance().Info("Entering LoginController.Login()");
            MyLogger.GetInstance().Info("Parameters are: new JavaScriptSerializer().Serialize(user)");

            if (!ModelState.IsValid) return View("Login");
            SecurityService ss = new SecurityService();
            Boolean success = ss.Authenticate(user);

            if (success)
            {
                MyLogger.GetInstance().Info("Exiting LoginController.Login() with login passing");
                return View("LoginPassed", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Exiting LoginController.Login() with login failing");
                return View("LoginFailed");
            }
        }

        [HttpGet]
        [CustomAuthorization]
        public ActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me.");
        }

        [HttpGet]
        [AspNetCacheProfile("CacheFor60Seconds")]
        public string GetUsers()
        {
            //get the default memory cache 
            var cache = MemoryCache.Default;

            //get users from the cache and if users do not exist in the cache, put them in the cache
            List<UserModel> users = cache.Get("Users") as List<UserModel>;
            if (users == null)
            {
                MyLogger.GetInstance().Info("Creating Users and putting them into the cache");
                //create a list of users 
                users = new List<UserModel>();
                users.Add(new UserModel("Kelsea", "Jondall"));
                users.Add(new UserModel("Brian", "Cantrell"));
                users.Add(new UserModel("Tony", "Stewart"));

                //save the users in the cache with 60s expiration policy 
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);
                cache.Set("Users", users, policy);
            } 
            else
            {
                MyLogger.GetInstance().Info("Got Users from the cache");
            }

            //return JSON serialized list of users 
            return new JavaScriptSerializer().Serialize(users);
        }
    }
}