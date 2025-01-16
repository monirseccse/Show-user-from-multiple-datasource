using Assignment.DbContexts;
using Assignment.Model.RequestDto;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Assignment.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity) => await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var id = idProperty.GetValue(entity);
                await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
            }
        }

        public async Task DeleteAsync(int id) => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));

    }
}
