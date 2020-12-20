using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity1_3.Services.Business
{
    public interface ILoggerService
    {
        void Initialize(ILogger logger);

        void TestLogger();
    }
}
