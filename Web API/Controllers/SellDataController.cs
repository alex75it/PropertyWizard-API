using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PropertyWizard.Core.Providers;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    [RoutePrefix("SellData")]
    public class SellDataController : ControllerBase
    {
        private SellDataProvider provider;

        public SellDataController()
        {
            ISellDataRepository sellDataREpository = new HMRawPriceDataRepository();
            provider = new SellDataProvider(sellDataREpository);
        }

        [HttpGet]
        [Route("list")]
        public List<HMRawPriceData> Search(string postCode)
        {
            var list = provider.List(postCode);
            return list;
        }
    }
}
