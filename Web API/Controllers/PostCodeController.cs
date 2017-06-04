using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.WebApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("postcode")]
    public class PostCodeController : ControllerBase
    {
        private readonly PostCodeRepository repository;

        //public PostCodeController(PostCodeRepository repository) {
        //    this.repository = repository;
        //}

        public PostCodeController() {
            this.repository = new PostCodeRepository();
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
    }
}