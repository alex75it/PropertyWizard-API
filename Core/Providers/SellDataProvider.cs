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

        public PagedResult<HMRawPriceData> List(string postCode, RequestPagingInfo paging)
        {
            // todo: try catch (validate filter)
            var filter = HMSellDataFilter.Create(postCode);

            var searchResult = repository.List(filter, paging.PageSize, paging.PageNumber);
         
            bool isLastPage = searchResult.NumberOfItems <= paging.PageSize * paging.PageNumber;

            var  pagedResult = PagedResult<HMRawPriceData>.Create(paging, searchResult.Items, isLastPage);

            return pagedResult;
        }

    }
}
