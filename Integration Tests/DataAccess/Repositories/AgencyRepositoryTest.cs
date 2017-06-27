using System;
using System.Linq;
using NUnit.Framework;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Bson.Serialization;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    // todo: semplify using RepositoryBase

    [TestFixture, Category("Agency")]
    public class AgencyReposoitoryTest
    {

        private AgencyRepository repository;

        private const string DATABASE_NAME = "property_wizard";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MapEntities();
        }

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

            var result = collection.DeleteOne(Builders<ZooplaListing>.Filter.Eq<int>(z => z.ListingId, listing.ListingId));
            if (!result.IsAcknowledged)
                Assert.Inconclusive("Delete pre existent record fails.");

            collection.InsertOne(listing);
        }

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
        }

        #endregion
    }
}
