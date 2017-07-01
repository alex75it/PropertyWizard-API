using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;
using PropertyWizard.Core.Providers;
using PropertyWizard.Core.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    //[Authorize]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("postcode")]
    public class PostCodeController : ControllerBase
    {
        private readonly PostCodeRepository repository;
        private StatisticsProvider statisticsProvider;

        //public PostCodeController(PostCodeRepository repository, StatisticsProvider statisticsProvider) {
        //    this.repository = repository;
        //     StatisticsProvider statisticsProvider
        //}

        public PostCodeController() {
            this.repository = new PostCodeRepository();
            IZooplaListingRepository zooplaListingRepository = new ZooplaListingRepository();
            IAgencyRepository agencyRepository = new AgencyRepository();
            this.statisticsProvider = new StatisticsProvider(zooplaListingRepository, agencyRepository);
        }

        // GET postcode
        /// <summary>
        /// Return all the post codes.
        /// </summary>
        [Route("")]
        public IEnumerable<PostCode> GetList()
        {
            logger.Info("GetList");
            var list = repository.List();
            return list;
        }

        // GET postcode/SE17
        /// <summary>
        /// Return the Post code with the given "code";
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("{code}")]
        public PostCode Get(string code)
        {
            logger.Info("Get(code)");
            var postcode = repository.Get(code);
            return postcode;
        }

        // POST api/postcode
        [Route("")]
        public void Post(PostCode data)
        {
            repository.Create(data);
        }

        // PUT postcode/5
        [Route("{code}")]
        public void Put(string code, PostCode data)
        {
            repository.Update(code, data);
        }

        // DELETE postcode/5
        [Route("{code}")]
        public void Delete(string code)
        {
            logger.Info($"Delete({code})");
            repository.Delete(code);
        }

        [Route("statistics")]
        public ICollection<AgencyData> GetStatistics(string code)
        {
            logger.Info($"GetStatistics({code})");

            return statisticsProvider.GetPostcodeStatistics(code);
        }
    }
}