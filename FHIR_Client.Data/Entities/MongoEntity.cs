using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FHIR_Client.Data.Entities
{
    public class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
