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
        public string PostCode { get; set; }


        public string Action { get; set; }

    }
}
