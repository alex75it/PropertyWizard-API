using System;
using System.Collections.Generic;
using System.Web.Mvc;

using log4net;

namespace PropertyWizard.WebApi.Filters
{
    public class LogRequestAttribute : IActionFilter
    {
        private static readonly ILog logger = LogManager.GetLogger("");

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // ..
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.InfoFormat("(HTML request) {0} {1} {2}",
                filterContext.RequestContext.HttpContext.Request.UserHostAddress,
                filterContext.RequestContext.HttpContext.Request.HttpMethod.ToString().PadRight(10),
                filterContext.RequestContext.HttpContext.Request.RawUrl
                );
        }
    }

}