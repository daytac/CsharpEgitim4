using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim4.Cervices
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database;
        public MongoDbConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("DbCharpEgitim4");
        }
        public IMongoCollection<BsonDocument> GetCustomerCollection()
        {
            return _database.GetCollection<BsonDocument>("Customers");
        }
    }
}
