using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Driver;

using PropertyWizard.Entities;
using MongoDB.Bson.Serialization;

namespace PropertyWizard.DataAccess.Repositories
{
    public interface IAgencyRepository
    {
        List<Agency> List();
    }

    public class AgencyRepository : RepositoryBase<Agency, string>, IAgencyRepository
    {
        public override string CollectionName { get { return "agencies"; }  }

        protected override string IdentityField { get { return "code"; } }

        protected override Action<BsonClassMap<Agency>> MappingAction
        {
            get
            {
                return (BsonClassMap<Agency> map) =>
                {
                    map.MapProperty(m => m.Code).SetElementName("code");
                    map.MapProperty(m => m.Name).SetElementName("name");
                };
            }
        }

        public new List<Agency> List()
        {
            //FieldDefinition<ZooplaListing> a = new (_AppDomain => _)
            var agencyNames = base.helper.GetCollection<ZooplaListing>(ZooplaListingRepository.COLLECTION_NAME)
                .Distinct<string>("agency_name", "{}").ToList();

            var agencies = new List<Agency>(agencyNames.Count);
            var index = 1;
            foreach (var name in agencyNames)
                agencies.Add(new Agency(index++.ToString().PadLeft(4, '0'), name));            

            return agencies;
        }
    }
}
