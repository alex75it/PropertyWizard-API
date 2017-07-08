using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;


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

        public List<TEntity> All()
        {
            try
            {
                var collection = helper.GetCollection<TEntity>(CollectionName);
                var list = collection.FindSync("{}").ToList();
                return list;
            }
            catch (Exception exc)
            {
                throw new Exception("Fail to execute All().", exc);
            }
        }

        public TEntity Get(TIdentifier id)
        {
            var item = Collection.Find(GetFilterById(id)).FirstOrDefault();
            return item;
        }

        //internal List<TEntity> Search(FilterDefinition<TEntity> filter)
        //{
        //    return Collection.Count(filter);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize">Number of items.</param>
        /// <param name="page">1-base page number</param>
        /// <returns></returns>
        public SearchResult<TEntity> Search(FilterDefinition<TEntity> filter, int pageSize, int page)
        {
            var itemsInPage = Collection.Find(filter).Skip(pageSize * page - 1).Limit(pageSize).ToList();
            var numberOfItems = Count(filter);

            return new SearchResult<TEntity>() {
                Items = itemsInPage,
                NumberOfItems = numberOfItems
            };
        }

        public long Count(FilterDefinition<TEntity> filter)
        {
            return Collection.Count(filter);
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
