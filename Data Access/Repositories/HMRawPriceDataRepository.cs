using PropertyWizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace PropertyWizard.DataAccess.Repositories
{
    public interface IHMRawPriceDataRepository 
    {
        List<HMRawPriceData> List();
    }

    public class HMRawPriceDataRepository : RepositoryBase<HMRawPriceData, Guid>, IHMRawPriceDataRepository
    {
        /*public List<HMRawPriceData> List()
        {
            this.List()
        }*/
        public override string CollectionName { get { return "hm-price-data-raw"; } }

        protected override string IdentityField
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override Action<BsonClassMap<HMRawPriceData>> MappingAction
        {
            get
            {
                return (BsonClassMap<HMRawPriceData> map) =>
                {
                    map.MapProperty(p => p.Id).SetElementName("_id");
                    map.MapProperty(m => m.InsertDate).SetElementName("create_date");

                    map.MapProperty(m => m.TrandsactionId).SetElementName("transaction_id");
                    map.MapProperty(m => m.Date).SetElementName("date");
                    map.MapProperty(m => m.Price).SetElementName("price");
                };
            }
        }
    }
}
