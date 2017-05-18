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

        public abstract string CollectionName { get; }
        
        public RepositoryBase()
        {
            MapEntity();
        }

        protected abstract void MapEntity();

        public List<T> List()
        {
            var collection = helper.GetCollection<T>(CollectionName);
            var list = collection.FindSync("{}").ToList();
            return list;
        }

    }
}
