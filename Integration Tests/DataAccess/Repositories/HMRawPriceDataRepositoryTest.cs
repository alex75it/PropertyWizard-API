using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Should;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.DataAccess.Filters;
using PropertyWizard.Entities;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    [TestFixture, Category("Sell data")]
    public class HMRawPriceDataRepositoryTest :RepositoryTestBase<HMRawPriceDataRepository>
    {
        [Test]
        public void List__should__ReturnAllFields()
        {
            string partialPostCode = "SE17";

            var sellData = CreateRecord();
            SaveRecord(sellData);


            var filter = HMSellDataFilter.Create(partialPostCode);

            // Act
            var list = repository.List(filter);

            if(list == null || list.Count == 0)
                Assert.Inconclusive("No records to check");

            var loadedSellData = list.Find(x => x.Id == sellData.Id);
            if (loadedSellData == null)
                Assert.Inconclusive("No record to check");

            Assert.AreEqual(sellData.Id, loadedSellData.Id);
        }

        [Test]
        public void List__when__Filtering_PartialPostCode__should__Return_OnlyRecordsThatPartialCodeStartsWithGivenValue()
        {
            string partialPostCode = "SE17"; // London partial post code
            HMSellDataFilter filter = HMSellDataFilter.Create(partialPostCode);

            // Act
            var list = repository.List(filter);

            Assert.IsNotNull(list);
            list.ShouldNotBeEmpty();

            list.All(x => x.PostCode.StartsWith(partialPostCode));
        }


        #region test utils

        private HMRawPriceData CreateRecord() {

            var data = new HMRawPriceData()
            {
                Id = Guid.NewGuid(),                
            };

            return data;
        }

        private HMRawPriceData SaveRecord(HMRawPriceData sellData)
        {
            return repository.Create(sellData);
        }

        #endregion

        [Test]
        public void List__PopulateAllFields()
        {
            // TODO
            Assert.Inconclusive(" create a record arnd reload it");


            string partialPostCode = "SE17"; // London partial post code
            HMSellDataFilter filter = HMSellDataFilter.Create(partialPostCode);

            // Act
            var list = repository.List(filter);

            

            Assert.IsNotNull(list);
            list.ShouldNotBeEmpty();

            list.All(x => x.PostCode.StartsWith(partialPostCode));
        }

    }
}
