using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using MongoDB.Driver;
using NUnit.Framework;

using PropertyWizard.WebApiDataAccess.Entities;
using PropertyWizard.WebApiDataAccess.Repositories;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{

    [TestFixture, Category("Zoopla listing")]
    public class ZooplaListingRepositoryTest
    {
        private ZooplaListingRepository repository;
        private const string DATABASE_NAME = "property_wizard";
        private string connectionString = ConfigurationManager.AppSettings["MongoDB connection string"];

        [SetUp]
        public void SetUp()
        {
            repository = new ZooplaListingRepository();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //DeleteTestRecord();
        }

        [Test]
        public void List()
        {
            CreateListing(new ZooplaListing(1, "postcode", DateTime.UtcNow));

            // Execute
            var list = repository.List();

            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
        }

        [Test]
        public void List__when__PassPostcode()
        {
            CreateListing(new ZooplaListing(1, "postcode", DateTime.UtcNow));

            // Execute
            var list = repository.List("postcode");

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count(), 1);
            Assert.AreEqual(list[0].ListingId, 1);
            Assert.AreEqual(list[0].PostCode, "postcode");
        }


        #region utilities

        private void CreateListing(ZooplaListing listing)
        {
            DeleteTestRecord(listing.ListingId); // clean if exists
            GetCollection().InsertOne(listing);
        }

        private void DeleteTestRecord(int listingId)
        {
            GetCollection().FindOneAndDelete(Builders<ZooplaListing>.Filter.Eq<int>(zl => zl.ListingId, listingId));
        }

        private IMongoCollection<ZooplaListing> GetCollection()
        {
            var collection = new MongoClient(connectionString).GetDatabase(DATABASE_NAME)
                .GetCollection<ZooplaListing>(repository.CollectionName);
            return collection;
        }

        #endregion

    }


}
