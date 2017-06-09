using PropertyWizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.Core.Entities
{
    public class AgencyData
    {
        public string AgencyCode { get; set; }
        public int NOProperties { get; set; }

        public AgencyData(string agencyCode, int noProperties)
        {
            AgencyCode = agencyCode;
            NOProperties = noProperties;
        }
    }
}
