namespace Vcmng.Infrastructure.Settings
{
    public interface IMongoDbSetting
    {
        string ConnectionString { get; }
        string Database { get; }
        string CategoryCollectionName { get; }
        string ProductCollectionName { get; }
    }
}
