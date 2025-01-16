using Assignment.Model.Domain;
using System.Text.Json;

namespace Assignment.Repositories
{
    public class JsonRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _filePath = ".json";

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var users = await GetAllAsync();
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            var entities = await GetAllAsync();
            var entityList = entities.ToList();
            entityList.Add(entity);
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(entityList));

        }

        public async Task UpdateAsync(T entity)
        {
            var entities = await GetAllAsync();
            var entityList = entities.ToList();
            var index = entityList.FindIndex(u => u.Id == entity.Id);
            if (index >= 0)
            {
                entityList[index] = entity;
                await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(entityList));
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entities = await GetAllAsync();
            var entityList = entities.ToList();
            entityList.RemoveAll(u => u.Id == id);
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(entityList));

        }
    }
}
