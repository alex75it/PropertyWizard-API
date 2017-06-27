using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.DataAccess.Repositories
{
    public interface IRepository
    {

    }

    public abstract class RepositoryBase<TEntity, TIdentifier> :IRepository
    {
        internal MongoHelper helper = new MongoHelper();

        public abstract string CollectionName { get; }

        protected abstract string IdentityField { get; }

        protected abstract Action<BsonClassMap<TEntity>> MappingAction { get; }

        public RepositoryBase()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
                BsonClassMap.RegisterClassMap<TEntity>(MappingAction);
        }

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
            var item = Collection.Find(GetFilterById(id)).FirstOrDefault();
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
