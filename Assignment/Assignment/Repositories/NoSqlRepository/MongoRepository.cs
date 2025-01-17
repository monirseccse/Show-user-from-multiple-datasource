using Assignment.DbContexts;
using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Assignment.Repositories.NoSqlRepository
{
    public class MongoRepository :IRepository
    {
        private readonly IMongoCollection<User> _collection;
        public MongoRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<User>("Users");  }
        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter = null, int skip = 0,int take =10)
        {
            if (filter == null)
            {
                return await _collection.Find(_ => true).Skip(skip).Limit(take).ToListAsync();
            }
           return await _collection.Find(filter).Skip(skip).Limit(take).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var data = await _collection.Find(Builders<User>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
            return data;
        }

        public async Task AddAsync(User entity) => await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(User entity)
        {
            var idProperty = typeof(User).GetProperty("Id");
            if (idProperty != null)
            {
                var id = idProperty.GetValue(entity);
                await _collection.ReplaceOneAsync(Builders<User>.Filter.Eq("Id", id), entity);
            }
        }

        public async Task DeleteAsync(int id) => await _collection.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));

        public async Task<long> CountAsync(Expression<Func<User, bool>> filter = null)
        {
            if(filter is null)
            return await _collection.CountDocumentsAsync(Builders<User>.Filter.Empty);
            return await _collection.CountDocumentsAsync(filter);
        }
    }
}
