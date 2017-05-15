using MongoDB.Driver;
using NUnit.Framework;
using PropertyWizard.DataAccess.Entities;
using PropertyWizard.WebApiDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    [TestFixture, Category("PostCode")]
    public class PostCodeRepositoryTest
    {
        private PostCodeRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new PostCodeRepository();
        }

        [Test]
        public void List()
        {

            CreatePostCode(new PostCode("Test 1", DateTime.UtcNow.ToString()));

            // Execute
            var list = repository.List();

            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
        }

        private void CreatePostCode(PostCode postCode)
        {
            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase("property-wizard").GetCollection<PostCode>("postcodes");

            collection.InsertOne(postCode);
        }

    }
}
