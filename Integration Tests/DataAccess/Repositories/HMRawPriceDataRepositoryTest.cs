using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using PropertyWizard.DataAccess.Repositories;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    [TestFixture, Category("HM")]
    public class HMRawPriceDataRepositoryTest :RepositoryTestBase<HMRawPriceDataRepository>
    {
        [Test]
        public void List()
        {
            // Act
            var data = repository.List();

            Assert.IsNotNull(data);
        }

    }
}
