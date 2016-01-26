using System;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace FHIR_Client.Data
{
    using Entities;
    public class MongoConnectionHandler<T> where T: IMongoEntity
    {
        public IMongoCollection<T> MongoCollection { get; private set; }
        public MongoConnectionHandler()
        {
            const string connectionString = "mongdb://localhost";
            var mongoClient = new MongoClient(connectionString);
            const string databaseName = "fhir_client";
            var db = mongoClient.GetDatabase(databaseName);
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}
