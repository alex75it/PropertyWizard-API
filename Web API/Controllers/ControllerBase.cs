using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using log4net;

namespace PropertyWizard.WebApi.Controllers
{
    public abstract class ControllerBase :ApiController
    {
        protected ILog logger;

        public ControllerBase()
        {
            logger = LogManager.GetLogger(GetType().Name);
        }
    }
}