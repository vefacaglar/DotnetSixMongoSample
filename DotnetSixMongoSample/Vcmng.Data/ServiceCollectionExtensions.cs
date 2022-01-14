using Microsoft.Extensions.DependencyInjection;
using Vcmng.Data.Abstractions;

namespace Vcmng.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMongoDbClient, MongoDbClient>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
