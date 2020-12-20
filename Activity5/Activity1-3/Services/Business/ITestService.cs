using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity1Part3.Services.Business {
    public interface ITestService {
        void Initialize(ILogger logger);

        void TestLogger();
    }
}
