using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PropertyWizard.Core.Providers;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;
using System.Web.Http.Cors;
using PropertyWizard.Core;

namespace PropertyWizard.WebApi.Controllers
{
    [RoutePrefix("SellData")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SellDataController : ControllerBase
    {
        private SellDataProvider provider;

        public SellDataController()
        {
            ISellDataRepository sellDataREpository = new HMRawPriceDataRepository();
            provider = new SellDataProvider(sellDataREpository);
        }

        //[HttpGet]
        //[Route("list")]
        //public List<HMRawPriceData> Search(string postCode)
        //{
        //    var list = provider.List(postCode);
        //}


        [HttpGet]
        [Route("list")]
        public PagedResult<HMRawPriceData> Search(string postCode, int pageSize, int page)
        {
            //[FromUri]RequestPagingInfo pagination
            var pagination = RequestPagingInfo.Create(pageSize, page);
            var result = provider.List(postCode, pagination);
            return result;
        }
    }
}
