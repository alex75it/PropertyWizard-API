using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using PropertyWizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.DataAccess.Repositories
{
    public class PostCodeRepository :RepositoryBase<PostCode, string>
    {
        public override string CollectionName { get { return "postcodes"; } }
        protected override string IdentityField { get { return "code"; } }

        public void Update(string code, PostCode data)
        {
            UpdateDefinition<PostCode> update = Builders<PostCode>.Update.Combine(
                Builders<PostCode>.Update.Set<string>(p => p.Description, data.Description),
                Builders<PostCode>.Update.Set<bool>(p => p.Enabled, data.Enabled)
            );

            base.Update(code, update);
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
                    pc.MapProperty(m => m.Enabled).SetElementName("enabled");
                });
            }
        }
    }
}
