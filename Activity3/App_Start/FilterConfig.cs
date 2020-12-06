using System.Web;
using System.Web.Mvc;

namespace Cantrell_Brian_CST247_Activity3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
