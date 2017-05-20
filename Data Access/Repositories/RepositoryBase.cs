using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity, TIdentifier> 
    {
        private MongoHelper helper = new MongoHelper();

        public abstract string CollectionName { get; }
        
        public RepositoryBase()
        {
            MapEntity();
        }

        protected abstract void MapEntity();

        public List<TEntity> List()
        {
            try
            {
                var collection = helper.GetCollection<TEntity>(CollectionName);
                var list = collection.FindSync("{}").ToList();
                return list;
            }
            catch (Exception exc)
            {
                throw new Exception("Fail to execute List().", exc);
            }
        }

        public TEntity Get(TIdentifier identifier)
        {
            string _id = identifier is string ?
                "\"" + identifier + "\"" :
                identifier.ToString()
                ;

            string filter = $"{{_id: {_id}}}";

            var item = helper.GetCollection<TEntity>(CollectionName)
                .FindAsync<TEntity>(filter).Result.FirstOrDefault();

            return item;
        }
    }
}
