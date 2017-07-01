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
        List<HMRawPriceData> List(HMSellDataFilter filter);
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
                    map.MapProperty(m => m.Action).SetElementName("action");
                };
            }
        }

        public List<HMRawPriceData> List(HMSellDataFilter filter)
        {
            var filterBuilder = Builders<HMRawPriceData>.Filter;
            FilterDefinition<HMRawPriceData> filterToApply = null;
            if (filter.PartialPostCode != null)
                filterToApply = filterBuilder.And(filterBuilder.Where(data => data.PostCode.StartsWith(filter.PartialPostCode)));
            else if (filter.ExactPostCode != null)
                filterToApply = filterBuilder.And(filterBuilder.Eq<string>(d => d.PostCode, filter.ExactPostCode));
            
            return base.Search(filterToApply);
        }

        public new List<HMRawPriceData> List()
        {
            throw new Exception("Operation not allowed. List methods should apply some filters.");
        }
    }
}
