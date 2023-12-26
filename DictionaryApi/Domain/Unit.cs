using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;

namespace DictionaryApi.Domain
{
    [BsonCollection("unit")]
    public class Unit : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("image")]
        public string Image { get; set; } = String.Empty;

    }
}
