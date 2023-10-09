using DictionaryApi.DataAccess.DbSetting;
using DictionaryApi.Repository;
using DictionaryApi.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DictionaryDbSetting>(builder.Configuration.GetSection("DictionaryDatabase"));

builder.Services.AddSingleton<IMongoDbSetting>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<DictionaryDbSetting>>().Value);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<IVocabularyService, VocabularyService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUnitHasVocabularyService, UnitHasVocabularyService>();
builder.Services.AddScoped<IFavoriteVocabularyService, FavoriteVocabularyService>();
builder.Services.AddScoped<IFavoriteUnitService, FavoriteUnitService>();

builder.Services.AddControllers();
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
