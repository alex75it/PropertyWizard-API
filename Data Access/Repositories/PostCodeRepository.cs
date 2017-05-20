using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using PropertyWizard.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public class PostCodeRepository :RepositoryBase<PostCode, string>
    {
        public override string CollectionName { get { return "postcodes"; } }
        protected override string IdentityField { get { return "code"; } }

        public IEnumerable<PostCode> List(string partialPostCode)
        {
            var list = new List<PostCode>() { };

            list.Add(new PostCode("EC1", "London EC1"));
            list.Add(new PostCode("EC2", "London EC2"));
            list.Add(new PostCode("EC3", "London EC3"));
            list.Add(new PostCode("SE17", "London SE17"));            
                        
            return list;
        }


        public PostCode Get(string code)
        {
            return List().SingleOrDefault(p => p.Code == code);
        }

        public new void Delete(string code)
        {
            base.Delete(code);
        }

        protected override void MapEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PostCode)))
            {
                BsonClassMap.RegisterClassMap<PostCode>(pc => {
                    pc.MapProperty(m => m.Code).SetElementName("code");
                    pc.MapProperty(m => m.Description).SetElementName("description");
                });
            }
        }
    }
}
