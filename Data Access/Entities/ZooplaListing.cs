using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.WebApiDataAccess.Entities
{
    public class ZooplaListing
    {
        public int ListingId { get; set; }

        public string  PostCode { get; set; }

        public DateTime LastPublishDate { get; set; }

        public decimal Price { get; set; }
        public string AgencyName { get; set; }

        public ZooplaListing(int listingId, string postCode, DateTime lastPublishDate)
        {
            ListingId = listingId;
            PostCode = postCode;
            LastPublishDate = lastPublishDate;
        }

    }
}
