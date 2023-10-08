namespace DictionaryApi.DataAccess.DbSetting
{
    public class DictionaryDbSetting : IMongoDbSetting
    {
        public string DatabaseName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
    }
}
