using System;
using System.Web.Http.Filters;

using log4net;


namespace PropertyWizard.WebApi.Filters
{
    public class LogApiExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger("");

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            logger.ErrorFormat("{0}", actionExecutedContext.Exception);
        }
    }
}