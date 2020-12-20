using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class TestLoggingService1Controller : Controller
    {
        private ILogger logger;

        public TestLoggingService1Controller(ILogger log)
        {
            logger = log;
        }

        // GET: TestLoggingService1
        public string Index()
        {
            logger.Info("testing logger 1");
            return "tested logger 1";
        }
    }
}