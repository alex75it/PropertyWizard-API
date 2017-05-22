using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using PropertyWizard.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Web_API;

namespace PropertyWizard.IntegrationTests.Web_API.Controllers
{
    [TestFixture]
    public class PostCodeControllerTest
    {

        private const string BASE_URL = "http://www.apitest.com/" +  "postcode";

        [OneTimeSetUp]
        public void OneTimeStUp()
        {

        }

        [Test]
        public void Post()
        {
            var method = HttpMethod.Post;
            var url = BASE_URL + "";
            //dynamic data = new
            //{
            //    code = "code",
            //    description = "description"
            //};

            string code = "code";
            string description = "description";
            var data = new PostCode(code, description);

            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            request.Content = new ObjectContent<PostCode>(data, formatter);

            // cleanup 
            DeletePostCode(code);


            using (var server = new HttpServer(GetConfiguration()))
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(request).Result;
            }
        }


        protected HttpConfiguration GetConfiguration()
        {
            HttpConfiguration configuration = new HttpConfiguration();
            //var dependencyResolver = new WindsorDependencyResolver(container);
            //configuration.DependencyResolver = dependencyResolver;
            WebApiConfig.Register(configuration);

            // remove all HostAuthenticationFilter due to the error "no OWIN Authentication manager..."
            foreach (var filter in configuration.Filters.Where(f => f.Instance is HostAuthenticationFilter).ToList())
                configuration.Filters.Remove(filter.Instance);

            return configuration;
        }

        #region utilities

        private void DeletePostCode(dynamic code)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
