using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

using PropertyWizard.Core.Providers;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("agency")]
    public class AgencyController : ControllerBase
    {
        private readonly AgencyProvider provider;

        public AgencyController()
        {
            IAgencyRepository agencyRepository = new AgencyRepository();
            this.provider = new AgencyProvider(agencyRepository);
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