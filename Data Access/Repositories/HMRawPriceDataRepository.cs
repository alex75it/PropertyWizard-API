using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson.Serialization;

using PropertyWizard.Entities;
using PropertyWizard.DataAccess.Filters;
using MongoDB.Driver;

namespace PropertyWizard.DataAccess.Repositories
{
    public interface ISellDataRepository 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize">Number of items</param>
        /// <param name="page">1-based page number</param>
        /// <returns></returns>
        SearchResult<HMRawPriceData> List(HMSellDataFilter filter, int pageSize, int page);
    }

    public class HMRawPriceDataRepository : RepositoryBase<HMRawPriceData, Guid>, ISellDataRepository
    {
        public override string CollectionName { get { return "hm-price-data-raw"; } }

        protected override string IdentityField { get { return "_id";  } }
        
        protected override Action<BsonClassMap<HMRawPriceData>> MappingAction
        {
            get
            {
                return (BsonClassMap<HMRawPriceData> map) =>
                {
                    map.MapProperty(p => p.Id).SetElementName("_id");
                    map.MapProperty(m => m.InsertDate).SetElementName("create_date");

                    map.MapProperty(m => m.TrandsactionId).SetElementName("transaction_id");
                    map.MapProperty(m => m.Date).SetElementName("date");
                    map.MapProperty(m => m.Price).SetElementName("price");
                    map.MapProperty(m => m.PropertyType).SetElementName("property_type");
                    map.MapProperty(m => m.PostCode).SetElementName("post_code");

                    map.MapProperty(m => m.HoldingType).SetElementName("holding_type");
                    map.MapProperty(m => m.YN).SetElementName("yn");

                    map.MapProperty(m => m.PAON).SetElementName("paon");
                    map.MapProperty(m => m.SAON).SetElementName("saon");
                    map.MapProperty(m => m.Street).SetElementName("street");
                    map.MapProperty(m => m.Locality).SetElementName("locality");
                    map.MapProperty(m => m.City).SetElementName("city");
                    map.MapProperty(m => m.District).SetElementName("distric");
                    map.MapProperty(m => m.County).SetElementName("county");

                    map.MapProperty(m => m.X).SetElementName("x");
                    map.MapProperty(m => m.Action).SetElementName("action");
                };
            }
        }

        public SearchResult<HMRawPriceData> List(HMSellDataFilter filter, int pageSize, int page)
        {
            var filterBuilder = Builders<HMRawPriceData>.Filter;
            FilterDefinition<HMRawPriceData> filterToApply = null;
            if (filter.PartialPostCode != null)
                filterToApply = filterBuilder.And(filterBuilder.Where(data => data.PostCode.StartsWith(filter.PartialPostCode)));
            else if (filter.ExactPostCode != null)
                filterToApply = filterBuilder.And(filterBuilder.Eq<string>(d => d.PostCode, filter.ExactPostCode));
                        
            return base.Search(filterToApply, pageSize, page);
        }

        public new List<HMRawPriceData> All()
        {
            throw new Exception("Operation not allowed. List methods should apply some filters.");
        }
    }
}
