using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Should;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.DataAccess.Filters;

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

        [Test]
        public void List_Filtering_PartialPostCode()
        {
            string partialPostCode = "SE17"; // London partial post code
            HMSellDataFilter filter = HMSellDataFilter.Create(partialPostCode);

            // Act
            var list = repository.List(filter);

            Assert.IsNotNull(list);
            list.ShouldBeEmpty();

            list.All(x => x.PostCode.StartsWith(partialPostCode));
        }

    }
}
