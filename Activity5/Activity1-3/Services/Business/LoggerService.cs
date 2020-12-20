using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1_3.Services.Business
{
    public class LoggerService : ILoggerService
    {
        private ILogger logger;

        public void Initialize(ILogger logger)
        {
            this.logger = logger;
        }

        public void TestLogger()
        {
            logger.Info("Testing the logging of our Logger Service.");
        }
    }
}