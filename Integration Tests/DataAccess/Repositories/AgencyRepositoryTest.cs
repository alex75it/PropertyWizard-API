using System;
using System.Linq;
using NUnit.Framework;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;
using MongoDB.Driver;
using System.Configuration;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    [TestFixture, Category("Agency")]
    public class AgencyReposoitoryTest
    {

        private AgencyRepository repository;

        private const string DATABASE_NAME = "property_wizard";

        [SetUp]
        public void SetUp()
        {
            repository = new AgencyRepository();
        }

        [Test]
        public void List()
        {
            string agencyName = "agency name";

            ZooplaListing listing = new ZooplaListing(1, "postcode", DateTime.Now) {
                AgencyName = agencyName
            };

            SaveListing(listing);

            // Act
            var agencies = repository.List();
           
            Assert.IsNotNull(agencies);
            Assert.IsTrue(agencies.Any(ag => ag.Name == agencyName));
        }

        #region utility
        private void SaveListing(ZooplaListing listing)
        {
            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(DATABASE_NAME)
                .GetCollection<ZooplaListing>(ZooplaListingRepository.COLLECTION_NAME);

            collection.DeleteOne(Builders<ZooplaListing>.Filter.Eq<int>(z => z.ListingId, listing.ListingId));

            collection.InsertOne(listing);
        }

        #endregion
    }
}
