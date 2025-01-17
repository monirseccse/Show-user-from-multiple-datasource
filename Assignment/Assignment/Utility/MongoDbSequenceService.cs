using MongoDB.Bson;
using MongoDB.Driver;

namespace Assignment.Utility
{
    public class MongoDbSequenceService
    {
        private readonly IMongoCollection<BsonDocument> _countersCollection;

        public MongoDbSequenceService(IMongoDatabase database)
        {
            _countersCollection = database.GetCollection<BsonDocument>("counters");
        }

        public async Task<int> GetNextSequenceValueAsync(string sequenceName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", sequenceName);
            var update = Builders<BsonDocument>.Update.Inc("seq", 1);

            var options = new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };

            var result = await _countersCollection.FindOneAndUpdateAsync(filter, update, options);
            return result["seq"].AsInt32;
        }
    }
}
