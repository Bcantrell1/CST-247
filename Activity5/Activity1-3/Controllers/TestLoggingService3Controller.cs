using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class TestLoggingService3Controller : Controller
    {
        private ILogger logger;
        private ILoggerService service;

        public TestLoggingService3Controller(ILogger log, ILoggerService svc)
        {
            logger = log;
            service = svc;
        }

        public string Index()
        {
            logger.Info("controller 3 log");
            service.TestLogger();

            return "controller 3 test";
        }
    }
}