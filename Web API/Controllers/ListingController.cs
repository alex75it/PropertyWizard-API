﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            var list = repository.List(postCode, int.MaxValue, 1).Items;

            return list;
        }

        [Route("/{postCode}?pageSize={pageSize}&page={page}")]
        public IEnumerable<ZooplaListing> GetList(string postCode, int pageSize, int page)
        {
            logger.Info("GetList");
            var list = repository.List(postCode, pageSize, page).Items;

            return list;
        }

    }
}