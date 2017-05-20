using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Entities
{
    public class ZooplaListing
    {
        public int ListingId { get; set; }

        public string  PostCode { get; set; }

        public DateTime LastPublishDate { get; set; }

        public ZooplaListing(int listingId, string postCode, DateTime lastPublishDate)
        {
            ListingId = listingId;
            PostCode = postCode;
            LastPublishDate = lastPublishDate;
        }

    }
}
