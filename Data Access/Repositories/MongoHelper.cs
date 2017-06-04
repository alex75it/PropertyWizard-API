using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.DataAccess.Repositories
{
    internal class MongoHelper
    {
        private string connectionString;
        private IMongoDatabase database;
        private const string DATABASE_NAME = "property_wizard";

        public string ConnectionString
        {
            get
            {
                if (connectionString == null)
                    connectionString = ConfigurationManager.AppSettings["MongoDB connection string"];
                return connectionString;
            }
        } 

        public IMongoDatabase Database
        {
            get
            {
                if (database == null)
                    database = new MongoClient(ConnectionString).GetDatabase(DATABASE_NAME);
                return database;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            IMongoCollection<T> collection = Database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}
