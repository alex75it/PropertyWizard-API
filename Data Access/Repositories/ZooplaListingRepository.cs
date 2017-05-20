using System;
using System.Collections.Generic;
using System.Linq;

using PropertyWizard.WebApiDataAccess.Entities;
using MongoDB.Bson.Serialization;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public class ZooplaListingRepository : RepositoryBase<ZooplaListing, int>
    {
        public override string CollectionName
        {
            get { return "zoopla-listings"; }
        }

        protected override void MapEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ZooplaListing)))
            {
                BsonClassMap.RegisterClassMap<ZooplaListing>(zl => {
                    zl.MapProperty(m => m.ListingId).SetElementName("listing_id");
                    zl.MapProperty(m => m.PostCode).SetElementName("postcode");
                    zl.MapProperty(m => m.LastPublishDate).SetElementName("last_published_date");
                });
            }
        }

        public List<ZooplaListing> List(string postCode)
        {
            throw new Exception("Not implemented");
        }
    }

}
