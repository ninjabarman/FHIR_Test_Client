using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FHIR_Client.Data.Services
{
    using Entities;
    public abstract class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler; 

        public virtual void Create(T entity)
        {
            try
            {
                MongoConnectionHandler.MongoCollection.InsertOne(
                    entity,
                    new InsertOneOptions
                    {
                        BypassDocumentValidation = false
                    });
            }
            catch (Exception ex)
            {
                //Something went wrong
            }
        }

        public virtual void Delete(string id)
        {
            MongoConnectionHandler.MongoCollection.DeleteOne( s => new ObjectId(id).Equals(s.Id));
        }

        public virtual T GetById(string id)
        {
            return MongoConnectionHandler.MongoCollection.Find(s => new ObjectId(id).Equals(s.Id)).First();
        }

        public abstract void Update(T entity);

        public EntityService()
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>();
        }
    }
}
