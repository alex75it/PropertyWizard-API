using PropertyWizard.WebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyWizard.WebApi.Core.Providers
{
    public class AgencyProvider
    {
        private static List<Agency> agencies;

        public List<Agency> GetAllAgencies()
        {
            if (agencies == null)
                LoadAgencies();

            return agencies;
        }

        private void LoadAgencies()
        {
            agencies = new List<Agency>() {
                new Agency("Fox1", "Foxtons - London Bridge"),
                new Agency("Cha1", "Chase Evans City & Aldgate"),
                new Agency("Atk1", "Atkinson Mcleod - Kennington"),
                new Agency("Nel1", "Nelsons"),
            };
        }
    }

}
