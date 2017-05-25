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

        public string PropertyType { get; set; } // enum
        public string Category { get; set; }  // enum

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Address { get; set; }

        public ZooplaListing(int listingId, string postCode, DateTime lastPublishDate)
        {
            ListingId = listingId;
            PostCode = postCode;
            LastPublishDate = lastPublishDate;
        }

        /*
         from Zoopla extractor code:
            //"date": datetime.utcnow(),

            //"floorplan_uris": listing.floorplan_uris,
            //"floorplan_text": listing.floorplan_text,
            //"latitude": listing.latitude,
            //"longitude": listing.longitude,/
         */

    }
}
