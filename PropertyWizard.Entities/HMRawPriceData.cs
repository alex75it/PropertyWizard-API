using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.Entities
{
    public class HMRawPriceData
    {
        public Guid Id { get; set; }
        public DateTime InsertDate { get; set; }

        public Guid TrandsactionId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }
        public string HoldingType { get; set; }
        public string PostCode { get; set; }
        public string YN { get; set; }

        public string PAON { get; set; }
        public string SAON { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string County { get; set; }

        public string X { get; set; }
        public string Action { get; set; }

    }
}
