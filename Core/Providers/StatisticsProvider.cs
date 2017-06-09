using PropertyWizard.Core.Entities;
using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.Core.Providers
{
    public class StatisticsProvider
    {
        private IZooplaListingRepository listingRepository;
        private IAgencyRepository agencyRepository;

        public StatisticsProvider(IZooplaListingRepository listingRepository, IAgencyRepository agencyRepository)
        {
            this.listingRepository = listingRepository;
            this.agencyRepository = agencyRepository;
        }

        public ICollection<AgencyData> GetPostcodeStatistics(string postCode)
        {
            ResetErrors();

            var agencies = agencyRepository.List();
            var listings = listingRepository.List(postCode);

            IDictionary<string, AgencyData> stats = new Dictionary<string, AgencyData>();

            listings.ForEach(l =>
            {
                string agencyCode = GetAgencyCode(agencies, l.AgencyName);
                if (agencyCode == null)
                {
                    AddToErrors($@"Unknown Agency for listing Id: {l.ListingId}. Agency name: ""{l.AgencyName}"".");
                }
                else
                {
                    if (!stats.ContainsKey(agencyCode))
                        stats.Add(agencyCode, new AgencyData(agencyCode, 0));

                    stats[agencyCode].NOProperties += 1;
                }
            });
            
            return stats.Values;
        }


        private string GetAgencyCode(List<Agency> agencies, string agencyName)
        {
            var agency = agencies.SingleOrDefault(ag => ag.Name == agencyName);
            return agency?.Code;
        }

        private void ResetErrors()
        {
            Errors = new List<string>();
        }

        public IList<string> Errors { get; private set; } = new List<string>(); 
        private void AddToErrors(string error)
        {
            Errors.Add(error);
        }
    }
}
