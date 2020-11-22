using Activity2Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();

            //add users to the list 
            users.Add(new UserModel("Troy Lee", "troyleee@TLD.com", "(123)-456-7890"));
            users.Add(new UserModel("Mitch Payton", "mpayton@procircuit.com", "(123)-456-7890"));
            users.Add(new UserModel("Eli Tomac", "eli@et3.com", "(123)-456-7890"));
            users.Add(new UserModel("Brian Cantrell", "bcantrell1@my.gcu.edu", "(123)-456-7890"));


            return View("Test", users);
        }
    }
}