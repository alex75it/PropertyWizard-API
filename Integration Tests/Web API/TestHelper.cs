using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

using MongoDB.Driver;

using PropertyWizard.Entities;

namespace PropertyWizard.IntegrationTests.WebApi
{
    internal class TestHelper
    {

        internal static void DeletePostCode(string code)
        {
            GetPostCodeCollection()
                .FindOneAndDelete(Builders<PostCode>.Filter.Eq<string>(p => p.Code, code));
        }

        internal static void CreatePostCode(PostCode postcode)
        {
            DeletePostCode(postcode.Code);

            GetPostCodeCollection()
                .InsertOne(postcode);
        }

        internal static PostCode GetPostCode(string code)
        {
            return GetPostCodeCollection()
                .Find(Builders<PostCode>.Filter.Eq<string>(p => p.Code, code))
                .FirstOrDefault();
        }

        private static IMongoCollection<PostCode> GetPostCodeCollection()
        {
            return GetCollection<PostCode>("postcodes");
        }

        private static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(ConfigurationManager.AppSettings["MongoDB database"])
                .GetCollection<T>(collectionName);

            return collection;
        }
    }
}
