using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using MongoDB. Bson;

namespace FHIR_Client.Data.Services
{
    using Entities;
    public interface IEntityService<T> where T : IMongoEntity
    {
        void Create(T entity);
        void Delete(string id);
        T GetById(string id);
        void Update(T entity);
    }
}
