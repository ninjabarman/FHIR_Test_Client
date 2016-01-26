using System;
using MongoDB.Bson;

namespace FHIR_Client.Data.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
