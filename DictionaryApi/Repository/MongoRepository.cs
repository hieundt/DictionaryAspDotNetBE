using System.Collections.Generic;
using DictionaryApi.DataAccess.CollectionNaming;
using DictionaryApi.DataAccess.DbSetting;
using DictionaryApi.Domain;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;


namespace DictionaryApi.Repository
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : IBaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

      

        public MongoRepository(IMongoDbSetting settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

        private protected string? GetCollectionName(Type documentType)
        {
            return (documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault() as BsonCollectionAttribute)?.CollectionName;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }
        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await _collection.Find(FilterId(id)).SingleOrDefaultAsync();
            return data;
        }
        public virtual async Task<TEntity> Update(string id, TEntity obj)
        {
            await _collection.ReplaceOneAsync(FilterId(id), obj);   
            return obj;
        }
        public virtual async Task<bool> Remove(string id)
        {
            var result = await _collection.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }
        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }
    }
}
