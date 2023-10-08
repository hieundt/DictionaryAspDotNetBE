using DictionaryApi.Domain;

namespace DictionaryApi.Repository
{
    public interface IMongoRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(string id, TEntity obj);
        Task<bool> Remove(string id);
    }
}
