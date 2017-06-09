using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;
using Should;

using PropertyWizard.Core.Providers;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.UnitTests.Core.Providers
{
    [TestFixture, Category("Statistics")]
    public class StatisticsProviderTest
    {
        private StatisticsProvider provider;
        private Mock<IZooplaListingRepository> listingRepository;
        private Mock<IAgencyRepository> agencyRepository;

        [SetUp]
        public void SetUp()
        {
            listingRepository = new Mock<IZooplaListingRepository>();
            agencyRepository = new Mock<IAgencyRepository>();
            provider = new StatisticsProvider(listingRepository.Object, agencyRepository.Object);
        }

        [Test]
        public void GetPostcodeStatistics__should__ReturnTheRightNumberOfAgencies()
        {
            string postcode = "postcode";

            string agencyName_1 = "Agency 1";
            string agencyName_2 = "Agency 2";

            List<Agency> agencies = new List<Agency>() {
                new Agency("A1", agencyName_1),
                new Agency("A2", agencyName_2),
            };

            var listings = new List<ZooplaListing>() {
                new ZooplaListing(1, postcode, DateTime.Now) { AgencyName = agencyName_1},
                new ZooplaListing(2, postcode, DateTime.Now) { AgencyName = agencyName_2},
                new ZooplaListing(3, postcode, DateTime.Now) { AgencyName = agencyName_1},
                new ZooplaListing(4, postcode, DateTime.Now) { AgencyName = "aaa"},
                new ZooplaListing(5, "aaa", DateTime.Now) { AgencyName = agencyName_2},
            };

            listingRepository.Setup(r => r.List(postcode)).Returns(listings);

            agencyRepository.Setup(r => r.List()).Returns(agencies);

            // Act
            var data = provider.GetPostcodeStatistics(postcode);

            Assert.IsNotNull(data);
            data.Count.ShouldEqual(agencies.Count);           
        }
    }
}
