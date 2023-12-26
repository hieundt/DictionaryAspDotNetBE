using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace DictionaryApi.Domain
{
    [BsonCollection("test")]
    public class Test : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("image")]
        [JsonPropertyName("image")]
        public string Image { get; set; } = String.Empty;

        [BsonElement("questions")]
        [JsonPropertyName("questions")]
        public List<string> Questions { get; set; } = new List<string>();

    }
}
