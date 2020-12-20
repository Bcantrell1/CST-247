using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class TestLoggingService2Controller : Controller
    {
        [Unity.Dependency]
        public ILogger logger { get; set; }


        // GET: TestLoggingService2
        public string Index()
        {
            logger.Info("test string");
            return "returning a string";
        }
    }
}