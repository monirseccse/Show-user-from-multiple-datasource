using MongoDB.Driver;

namespace Assignment.DbContexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            var databaseName = configuration["Database:MongoDatabaseName"];
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException("MongoDB database name is not configured.");

            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
