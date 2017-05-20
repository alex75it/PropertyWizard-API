using System;
using System.Collections.Generic;
using System.Linq;

using PropertyWizard.WebApiDataAccess.Entities;

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
            
        }

        public List<ZooplaListing> List(string postCode)
        {
            throw new Exception("Not implemented");
        }
    }

}
