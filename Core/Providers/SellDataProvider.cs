using System;
using System.Collections.Generic;
using System.Linq;

using PropertyWizard.DataAccess.Filters;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.Core.Providers
{
    public class SellDataProvider
    {
        private ISellDataRepository repository;

        public SellDataProvider(ISellDataRepository sellDataRepository)
        {
            repository = new HMRawPriceDataRepository();
        }

        public List<HMRawPriceData> List(string postCode)
        {
            // todo: try catch (validate filter)
            var filter = HMSellDataFilter.Create(postCode);

            var result = repository.List(filter);
            return result;
        }

    }
}
