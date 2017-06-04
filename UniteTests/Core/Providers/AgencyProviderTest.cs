using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using PropertyWizard.Core.Providers;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.UnitTests.Core.Providers
{
    [TestFixture]
    public class AgencyProviderTest
    {
        //[Test]
        //public void GetAllAgencies()
        //{
        //    Mock<IAgencyRepository> agencyRepositoryMock = new Mock<IAgencyRepository>();

        //    IEnumerable<Agency> agencies = new List<Agency>() {
        //        new Agency("", "")
        //    };

        //    agencyRepositoryMock.Setup(r => r.List()).Returns(agencies);

        //    var provider = new AgencyProvider(agencyRepositoryMock.Object);

        //    // Act
        //    var agencies = provider.GetAllAgencies();
        //}

    }
}
