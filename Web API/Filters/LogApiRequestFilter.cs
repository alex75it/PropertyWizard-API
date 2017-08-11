using System;
using System.Web.Http.Controllers;

using log4net;

namespace PropertyWizard.WebApi.Filters
{    
    public class LogApiRequestFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger("");

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
           logger.InfoFormat("(API request) {0} {1} {2}",               
               "", // Not found how to obtain the IP address of the client
               actionContext.Request.Method.ToString().PadRight(10),
               actionContext.Request.RequestUri
           );
        }
    }
}