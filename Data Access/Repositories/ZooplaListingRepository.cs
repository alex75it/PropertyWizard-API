using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using PropertyWizard.Entities;

namespace PropertyWizard.DataAccess.Repositories
{
    public interface IZooplaListingRepository
    {
        SearchResult<ZooplaListing> List(string postCode, int pageSize, int pageNumber);
    }

    public class ZooplaListingRepository : RepositoryBase<ZooplaListing, int>, IZooplaListingRepository
    {
        public const string COLLECTION_NAME = "zoopla-listings";
        public override string CollectionName { get { return COLLECTION_NAME; } }
        protected override string IdentityField { get { return "listing_id"; } }

        protected override Action<BsonClassMap<ZooplaListing>> MappingAction
        {
            get
            {
                return (BsonClassMap<ZooplaListing> zl) => {
                    zl.MapProperty(m => m.ListingId).SetElementName("listing_id");
                    zl.MapProperty(m => m.PostCode).SetElementName("postcode");
                    zl.MapProperty(m => m.LastPublishDate).SetElementName("last_published_date");
                    zl.MapProperty(m => m.Price).SetElementName("price");
                    zl.MapProperty(x => x.AgencyName).SetElementName("agency_name");
                    zl.MapProperty(x => x.PropertyType).SetElementName("property_type");
                    zl.MapProperty(x => x.Category).SetElementName("category");

                    zl.MapProperty(x => x.Latitude).SetElementName("latitude");
                    zl.MapProperty(x => x.Longitude).SetElementName("longitude");

                    zl.MapProperty(x => x.Address).SetElementName("full_address");
                };
            }
        }

        public SearchResult<ZooplaListing> List(string postCode, int pageSize, int pageNumber)
        {
            var filter = Builders<ZooplaListing>.Filter.Eq<string>(zl => zl.PostCode, postCode);
            return base.Search(filter, pageSize, pageNumber);
        }
    }

}
