using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.DataAccess.Filters
{
    public class HMSellDataFilter
    {
        public string PartialPostCode { get; set; }
        public string ExactPostCode { get; set; }

        private HMSellDataFilter(string partialPostCode, string exactPostCode)
        {
            PartialPostCode = partialPostCode;
            ExactPostCode = exactPostCode;
        }

        public static HMSellDataFilter Create(string partialOrExactPostCode)
        {
            if (string.IsNullOrWhiteSpace(partialOrExactPostCode))
                throw new ArgumentException("Partial or Exact post code must be specified");

            partialOrExactPostCode = partialOrExactPostCode.ToUpperInvariant();

            string partialPostCode = null;
            string exactPostCode = null;

            if (partialOrExactPostCode.Length <= 4)
                partialPostCode = partialOrExactPostCode;
            else
                exactPostCode = partialOrExactPostCode;

            HMSellDataFilter filter = new HMSellDataFilter(partialPostCode, exactPostCode);


            filter.Validate();

            return filter;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(PartialPostCode) && string.IsNullOrWhiteSpace(ExactPostCode))
                throw new Exception($"Partial post code or Exact post code must be specified");
        }
    }
}
