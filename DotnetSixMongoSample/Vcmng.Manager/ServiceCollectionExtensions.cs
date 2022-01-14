using Microsoft.Extensions.DependencyInjection;
using Vcmng.Manager.Abstractions;

namespace Vcmng.Manager
{
    public static class ServiceCollectionExtensions
    {
        public static void AddManagerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
        }
    }
}
