using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity, TIdentifier> 
    {
        internal MongoHelper helper = new MongoHelper();

        public abstract string CollectionName { get; }
        
        public RepositoryBase()
        {
            MapEntity();
        }

        protected abstract void MapEntity();
        protected abstract string IdentityField { get; }

        public TEntity Create(TEntity item)
        {
            Collection.InsertOne(item);
            return item;
        }

        public void Update(TIdentifier id, UpdateDefinition<TEntity> update)
        {
            Collection.UpdateOne(GetFilterById(id), update);
        }

        public void Delete(TIdentifier id)
        {
            Collection.DeleteOne( GetFilterById(id) );
        }

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

        public TEntity Get(TIdentifier id)
        {
            var item = Collection.Find(GetFilterById(id)).First();
            return item;
        }

        internal List<TEntity> Search(FilterDefinition<TEntity> filter)
        {
            return Collection.Find(filter).ToList();
        }

        private IMongoCollection<TEntity> Collection
        {
            get { return helper.GetCollection<TEntity>(CollectionName);  }
        }

        public FilterDefinition<TEntity> GetFilterById(TIdentifier id)
        {
            string idValue = id is string ?
                "\"" + id + "\"" :
                id.ToString();

            string filter = $"{{{IdentityField}: {idValue}}}";
            return filter;
        }
    }
}
