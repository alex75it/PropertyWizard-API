using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

using PropertyWizard.WebApiDataAccess.Entities;
using PropertyWizard.WebApiDataAccess.Repositories;

namespace PropertyWizard.WebApi.Controllers
{
    [EnableCors(origins: "http://propertywizard.org", headers: "*", methods: "*")]
    [RoutePrefix("listing")]
    public class ListingController : ControllerBase
    {
        private readonly ZooplaListingRepository repository;

        public ListingController()
        {
            this.repository = new ZooplaListingRepository();
        }

        // GET listing/
        [Route("/{postCode}")]
        public IEnumerable<ZooplaListing> GetList(string postCode)
        {
            logger.Info("GetList");
            var list = repository.List(postCode);

            return list;
        }

    }
}