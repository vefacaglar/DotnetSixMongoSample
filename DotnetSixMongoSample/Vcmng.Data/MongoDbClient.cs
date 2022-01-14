using MongoDB.Driver;
using Vcmng.Data.Abstractions;
using Vcmng.Infrastructure.Settings;

namespace Vcmng.Data
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDbSetting _settings;

        public MongoDbClient(
            IMongoDbSetting settings
            )
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            _settings = settings;
        }

        public IMongoDatabase Database
        {
            get
            {
                return _mongoClient.GetDatabase(_settings.Database);
            }
        }
    }
}
