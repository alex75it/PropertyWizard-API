using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using MongoDB.Driver;

using PropertyWizard.Entities;
using PropertyWizard.WebApi;
using MongoDB.Bson.Serialization;

namespace PropertyWizard.IntegrationTests.WebApi.Controllers
{
    [TestFixture]
    public class PostCodeControllerTest
    {

        private const string BASE_URL = "http://www.apitest.com/" +  "postcode";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MapEntities();
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
            bool enabled = !default(bool);
            var data = new PostCode(code, description, enabled);

            TestHelper.DeletePostCode(code);

            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            request.Content = new ObjectContent<PostCode>(data, formatter);

            // Act
            using (var server = new HttpServer(GetConfiguration()))
            using (var client = new HttpClient(server))
            {
                var response = client.SendAsync(request).Result;
            }

            PostCode postCode = TestHelper.GetPostCode(code);
            Assert.IsNotNull(postCode);
            Assert.AreEqual(description, postCode.Description);
        }

        [Test]
        public void Update()
        {
            var method = HttpMethod.Put;
            

            string code = "code";
            string description = "description";
            bool enabled = default(bool);

            var url = $"{BASE_URL}/{code}";

            var postCode = new PostCode(code, description, enabled);
            TestHelper.CreatePostCode(postCode);

            postCode.Description += " chanage";
            postCode.Enabled = !postCode.Enabled;

            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            request.Content = new ObjectContent<PostCode>(postCode, formatter);

            // Act
            using (var server = new HttpServer(GetConfiguration()))
            using (var client = new HttpClient(server))
            {
                var response = client.SendAsync(request).Result;
            }

            var postCodeUpdated = TestHelper.GetPostCode(code);
            Assert.IsNotNull(postCodeUpdated);
            Assert.AreEqual(postCode.Description, postCodeUpdated.Description);
            Assert.AreEqual(postCode.Enabled, postCodeUpdated.Enabled);
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

        private void MapEntities()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ZooplaListing)))
            {
                BsonClassMap.RegisterClassMap<ZooplaListing>(zl => {
                    zl.MapProperty(m => m.ListingId).SetElementName("listing_id");
                    zl.MapProperty(m => m.PostCode).SetElementName("postcode");
                    zl.MapProperty(m => m.LastPublishDate).SetElementName("last_published_date");
                    zl.MapProperty(m => m.Price).SetElementName("price");
                    zl.MapProperty(x => x.AgencyName).SetElementName("agency_name");
                    zl.MapProperty(x => x.PropertyType).SetElementName("property_type");
                    zl.MapProperty(x => x.Category).SetElementName("category");

                    zl.MapProperty(x => x.Latitude).SetElementName("latitude");
                    zl.MapProperty(x => x.Longitude).SetElementName("longitude");

                    zl.MapProperty(x => x.Address).SetElementName("full_address");
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(PostCode)))
            {
                BsonClassMap.RegisterClassMap<PostCode>(pc => {
                    pc.MapProperty(m => m.Code).SetElementName("code");
                    pc.MapProperty(m => m.Description).SetElementName("description");
                    pc.MapProperty(m => m.Enabled).SetElementName("enabled");
                });
            }
        }

        #endregion
    }
}
