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

        private const string DATABASE_NAME = "property_wizard";

        [SetUp]
        public void SetUp()
        {
            repository = new PostCodeRepository();            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //DeleteTestRecord();
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
            DeleteTestRecord(postCode.Code); // clean if exists

            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(DATABASE_NAME)
                .GetCollection<PostCode>("postcodes");

            collection.InsertOne(postCode);
        }

        private void DeleteTestRecord(string code)
        {
            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(DATABASE_NAME)
                .GetCollection<PostCode>("postcodes");

            collection.FindOneAndDelete(Builders<PostCode>.Filter.Eq<string>(p => p.Code, code));
        }

    }
}
