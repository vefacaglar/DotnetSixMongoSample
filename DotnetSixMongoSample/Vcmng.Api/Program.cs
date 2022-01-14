using Microsoft.Extensions.Options;
using Vcmng.Data;
using Vcmng.Infrastructure.Settings;
using Vcmng.Manager;
using Vcmng.Manager.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<ICacheProvider, RedisCacheProvider>();
builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection(nameof(MongoDbSetting)));
builder.Services.AddSingleton<IMongoDbSetting>(t => t.GetRequiredService<IOptions<MongoDbSetting>>().Value);
builder.Services.AddDataDependencies();
builder.Services.AddManagerDependencies();
builder.Services.AddControllers(options => options.Filters.Add(new ServiceExceptionInterceptor()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
