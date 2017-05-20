using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using MongoDB.Driver;
using NUnit.Framework;
using Should;

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

        [OneTimeSetUp]        
        public void OneTimeSetUp()
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
            var listing = new ZooplaListing(1, "postcode", DateTime.UtcNow);
            CreateListing(listing);

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

        [Test]
        public void Get()
        {
            var listing = new ZooplaListing(1, "postcode", DateTime.UtcNow);
            listing.Price = 1.23m;
            listing.AgencyName = "agency name";
            CreateListing(listing);

            // Act
            var savedListing = repository.Get(listing.ListingId);

            Assert.IsNotNull(savedListing);
            savedListing.ListingId.ShouldEqual(listing.ListingId);
            savedListing.PostCode.ShouldEqual(listing.PostCode);
            Assert.IsTrue(savedListing.LastPublishDate - listing.LastPublishDate < TimeSpan.FromMilliseconds(10));
            savedListing.Price.ShouldEqual(listing.Price);
            savedListing.AgencyName.ShouldEqual(listing.AgencyName);
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
