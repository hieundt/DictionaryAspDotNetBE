using System.Security.Claims;
using DictionaryApi.DataAccess.DbSetting;
using DictionaryApi.Repository;
using DictionaryApi.Service;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;


var builder = WebApplication.CreateBuilder(args);

//var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
//ConventionRegistry.Register("camel case", conventionPack, t => true);

// Add services to the container.
builder.Services.Configure<DictionaryDbSetting>(builder.Configuration.GetSection("DictionaryDatabase"));

builder.Services.AddSingleton<IMongoDbSetting>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<DictionaryDbSetting>>().Value); 


//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<IVocabularyService, VocabularyService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUnitHasVocabularyService, UnitHasVocabularyService>();
builder.Services.AddScoped<IFavoriteVocabularyService, FavoriteVocabularyService>();
builder.Services.AddScoped<IFavoriteUnitService, FavoriteUnitService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestHistoryService, TestHistoryService>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

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

app.MapGet("/", () => "Hello, World!");
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
    .RequireAuthorization();

app.MapControllers();

app.Run();
