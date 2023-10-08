namespace DictionaryApi.DataAccess.DbSetting
{
    public interface IMongoDbSetting
    {
        string DatabaseName { get; set; } 
        string ConnectionString { get; set; } 
    }
}
