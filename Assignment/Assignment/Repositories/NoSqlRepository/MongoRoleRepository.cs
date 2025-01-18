using Assignment.DbContexts;
using Assignment.Model.Domain;
using MongoDB.Driver;

namespace Assignment.Repositories.NoSqlRepository
{
    public class MongoRoleRepository : IRoleRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public MongoRoleRepository(MongoDbContext context)
        {
            _userCollection = context.GetCollection<User>("Users");
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _userCollection.Aggregate()
                .Group(u => u.Role, g => new { Role = g.Key }) 
                .ToListAsync();

            return roles.Select(r => r.Role);
        }
    }
}
