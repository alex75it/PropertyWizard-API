using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

using PropertyWizard.WebApi.Core.Providers;
using PropertyWizard.WebApi.Core.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("agency")]
    public class AgencyController : ControllerBase
    {
        private readonly AgencyProvider provider;

        public AgencyController()
        {
            this.provider = new AgencyProvider();
        }

        // GET agency/
        public IEnumerable<Agency> GetList()
        {
            logger.Info("GetList");
            var list = provider.GetAllAgencies();

            return list;
        }

    }

}