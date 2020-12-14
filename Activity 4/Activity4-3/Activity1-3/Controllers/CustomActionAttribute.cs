using Activity1_3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        //called after an Action Method is exectued
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger.GetInstance().Info("Exiting Controller: " + name);
        }

        //called before an Action Method is executed
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger.GetInstance().Info("Entering Controller: " + name);
        }
    }
}