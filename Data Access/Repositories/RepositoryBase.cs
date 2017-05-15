using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public abstract class RepositoryBase<T>
    {
        private MongoHelper helper = new MongoHelper();

        public RepositoryBase()
        {
            CollectionName = typeof(T).Name;
        }

        public string CollectionName { get; private set; }

        public List<T> List()
        {
            var recordsNumber = helper.GetCollection<BsonDocument>("postcodes").Count(FilterDefinition<BsonDocument>.Empty);

            var collection = helper.GetCollection<T>(CollectionName);

            var list = collection.FindSync(FilterDefinition<T>.Empty).ToList();
            return list;
        }

    }
}
