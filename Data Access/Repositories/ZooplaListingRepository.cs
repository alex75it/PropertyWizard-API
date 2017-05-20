using System;
using System.Collections.Generic;
using System.Linq;

using PropertyWizard.WebApiDataAccess.Entities;
using MongoDB.Bson.Serialization;
using static MongoDB.Bson.Serialization.BsonDeserializationContext;
using MongoDB.Driver;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public class ZooplaListingRepository : RepositoryBase<ZooplaListing, int>
    {        
        public override string CollectionName { get { return "zoopla-listings"; } }
        protected override string IdentityField { get { return "listing_id"; } }

        protected override void MapEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ZooplaListing)))
            {
                BsonClassMap.RegisterClassMap<ZooplaListing>(zl => {
                    zl.MapProperty(m => m.ListingId).SetElementName("listing_id");
                    zl.MapProperty(m => m.PostCode).SetElementName("postcode");
                    zl.MapProperty(m => m.LastPublishDate).SetElementName("last_published_date");
                    zl.MapProperty(m => m.Price).SetElementName("price");
                    zl.MapProperty(x => x.AgencyName).SetElementName("agency_name");
                });
            }
        }

        public List<ZooplaListing> List(string postCode)
        {
            var filter = Builders<ZooplaListing>.Filter.Eq<string>(zl => zl.PostCode, postCode);
            return base.Search(filter);
        }
    }

}
