using Assignment.Model.Domain;
using Assignment.Repositories;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        private readonly IServiceProvider _serviceProvider;

        public UserService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task AddAsync(User model)
        {
            throw new NotImplementedException();
        }

        public IRepository<User> GetRepository(string dataSource)
        {
            return dataSource.ToLower() switch
            {
                "sql" => _serviceProvider.GetRequiredService<RDBMSRepository<User>>(),
                "mongo" => _serviceProvider.GetRequiredService<MongoRepository<User>>(),
                _ => throw new NotSupportedException("Invalid data source")
            };
         }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, User model)
        {
            throw new NotImplementedException();
        }
    }
}
