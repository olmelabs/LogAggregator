using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OlmeLabs.LogAggregator.Configuration;
using OlmeLabs.LogAggregator.Models;

namespace OlmeLabs.LogAggregator.Repositories
{
    /// <summary>
    /// Mongo DB Storage
    /// </summary>
    public class MongoDbStorage : IStorage
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public MongoDbStorage(IAppSettings settings)
        {
            if (_client == null && _database == null)
            {
                _client = new MongoClient(settings.MongoConnectString);
                _database = _client.GetDatabase(settings.MongDbName);

                //idempotent - create index only if not exist
                var collection = _database.GetCollection<BsonDocument>("LogEntry");
                var keys = Builders<BsonDocument>.IndexKeys.Text("Content");
                collection.Indexes.CreateOne(keys);
                keys = Builders<BsonDocument>.IndexKeys.Descending("StoreDate");
                collection.Indexes.CreateOne(keys);
            }
        }

        public async Task StoreAsync(LogEntry entry)
        {
            var collection = _database.GetCollection<BsonDocument>("LogEntry");
            await collection.InsertOneAsync(Mapper.Map<BsonLogEntry>(entry).ToBsonDocument());
        }

        public async Task<SearchResults> SearchAsync(SearchOptions searchOptions)
        {
            long count = 0;
            FilterDefinition<BsonDocument> filter = null;
            SortDefinition<BsonDocument> sort = null;

            var collection = _database.GetCollection<BsonDocument>("LogEntry");

            if (searchOptions.Mode == SearchMode.RecentPage)
            {
                filter = new BsonDocument();
                sort = Builders<BsonDocument>.Sort.Descending("StoreDate");

                count = searchOptions.PageSize;
            }
            else if (searchOptions.Mode == SearchMode.Keywords)
            {
                if (string.IsNullOrWhiteSpace(searchOptions.Keywords))
                    return new SearchResults {Count = 0};

                filter = Builders<BsonDocument>.Filter.Text($"\"{searchOptions.Keywords.Trim()}\"");
                sort = Builders<BsonDocument>.Sort.Descending("StoreDate");

                count = await collection.CountAsync(filter);
            }

            int skipCount = (searchOptions.PageSize)*(searchOptions.CurrentPage - 1);
                if (skipCount >= count)
                    return new SearchResults {Count = count};

                var bsonList =
                    await collection.Find(filter)
                        .Sort(sort)
                        .Skip(skipCount)
                        .Limit(searchOptions.PageSize).ToListAsync();

               var results = BsonSerializer.Deserialize<List<BsonLogEntry>>(bsonList.ToJson());

            return new SearchResults
            {
                Count = count,
                Result = Mapper.Map<List<LogEntry>>(results)
            };
        }

        public async Task<LogEntry> GetById(string id)
        {
            var collection = _database.GetCollection<BsonLogEntry>("LogEntry");

            var filter = Builders<BsonLogEntry>.Filter.Eq("Id", ObjectId.Parse(id));

            var doc = await collection.Find(filter).FirstOrDefaultAsync();

            return doc == null ? null : Mapper.Map<LogEntry>(doc);
        }
    }
}