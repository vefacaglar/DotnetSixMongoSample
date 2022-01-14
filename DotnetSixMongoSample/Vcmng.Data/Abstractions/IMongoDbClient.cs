using MongoDB.Driver;

namespace Vcmng.Data.Abstractions
{
    public interface IMongoDbClient
    {
        IMongoDatabase Database { get; }
    }
}
