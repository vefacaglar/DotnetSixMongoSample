namespace Vcmng.Infrastructure.Settings
{
    public class MongoDbSetting : IMongoDbSetting
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string CategoryCollectionName { get; set; }

        public string ProductCollectionName { get; set; }
    }
}
