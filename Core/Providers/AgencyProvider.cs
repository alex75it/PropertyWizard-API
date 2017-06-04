using System;
using System.Collections.Generic;
using System.Linq;

using PropertyWizard.Entities;
using PropertyWizard.DataAccess.Repositories;

namespace PropertyWizard.Core.Providers
{
    public class AgencyProvider
    {
        private IAgencyRepository agencyRepository;

        private static List<Agency> agencies;

        public AgencyProvider(IAgencyRepository agencyRepository)
        {
            this.agencyRepository = agencyRepository;
        }

        public List<Agency> GetAllAgencies()
        {
            if (agencies == null)
                LoadAgencies();

            return agencies;
        }

        private void LoadAgencies()
        {
            agencies = agencyRepository.List();
        }
    }

}
